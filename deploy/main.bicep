@description('The prefix to be used in naming of resources')
param namePrefix string = 'azuredesignstudio'

@description('The name of the ACR that will be deployed')
param acrName string = '${namePrefix}-acr'

@description('The SKU size for the ACR')
param acrSku string = 'Basic'

@description('Name of the container image in ACR')
param containerImage string = namePrefix

@description('Name of the App Service Plan that will be deployed.')
param appServicePlanName string = '${namePrefix}-plan'

@description('The SKU size for our App Service Plan')
param appServicePlanSKU string = 'S1'

@description('The capacity size for our App Service Plan')
param appServiceCapacityCount int = 1

@description('Name of the App Service that will be deployed')
param appServiceName string = namePrefix

@description('The name of the Virtual Network')
param virutalNetworkName string = '${namePrefix}-vnet'

@description('The name of the subnet in the vNET')
param subnetName string = 'WebappSubnet'

@description('Name of the App Insights Instance')
param appInsightsName string = '${namePrefix}-ai'

@description('Name of the SQL Server')
param sqlServerName string = '${namePrefix}-sql'

@description('The admin username for the SQL Server')
param sqlAdminLogin string = 'sysadmin'

@secure()
@description('The admin password for the SQL Server')
param sqlAdminPassword string

@description('The admin AAD username for the SQL Server')
param adSqlAdminLogin string

@description('The admin SID of AAD user for the SQL Server')
param adSqlAdminSid string

@description('Name of the SQL Database')
param sqlDatabaseName string = 'adsdb'

@description('The name of the Azure Storage Account')
param storageAccountName string = namePrefix

@description('The SKU size of the Storage Account')
param storageSku string = 'Standard_ZRS'

@description('Name of the blob container')
param blobContainerName string = '$web'

@description('Location to deploy the Azure resources too. Default is the location of the resource group')
param location string = resourceGroup().location

module appServicePlan 'modules/appServicePlan.bicep' = {
  name: appServicePlanName
  params: {
    appServiceCapacityCount: appServiceCapacityCount
    appServicePlanName: appServicePlanName
    appServicePlanSKU: appServicePlanSKU
    location: location
  }
}

module containerRegistry 'modules/containerRegistry.bicep' = {
  name: acrName
  params: {
    acrName: acrName
    acrSku: acrSku
    location: location
  }
}

module appService 'modules/appService.bicep' = {
  name: appServiceName
  params: {
    acrName: acrName
    appServiceName: appServiceName
    appServicePlanId: appServicePlan.outputs.appServicePlanId
    containerImage: containerImage
    containerRegistryLoginServer: containerRegistry.outputs.loginServer
    subnetResourceId: virtualNetwork.properties.subnets[0].id
    location: location
  }
}

resource virtualNetwork 'Microsoft.Network/virtualNetworks@2021-05-01' = {
  name: virutalNetworkName
  location: location
  properties: {
    addressSpace: {
      addressPrefixes: [
        '10.2.0.0/20'
      ]
    }
    subnets: [
      {
        name: subnetName
        properties: {
          addressPrefix: '10.2.0.0/20'
          delegations: [
            {
              name: 'appServiceDelegation'
              properties: {
                serviceName: 'Microsoft.Web/serverfarms'
              }
            }
          ]
          serviceEndpoints: [
            {
              locations: [
                location
              ]
              service: 'Microsoft.Sql'
            }
          ]
        }
      }
    ]
  }
}

// App Insights
resource appInsights 'Microsoft.Insights/components@2020-02-02' = {
  name: appInsightsName
  location: location
  kind: 'web'
  properties: {
    Application_Type: 'web'
  }
}

// SQL Database
resource sqlServer 'Microsoft.Sql/servers@2021-08-01-preview' = {
  name: sqlServerName
  location: location 
  identity: {
    type: 'SystemAssigned'
  }
  properties: {
    administratorLogin: sqlAdminLogin
    administratorLoginPassword: sqlAdminPassword
    administrators: {
      administratorType: 'ActiveDirectory'
      azureADOnlyAuthentication: false
      login: adSqlAdminLogin
      principalType: 'User'
      sid: adSqlAdminSid
      tenantId: subscription().tenantId
    }
    publicNetworkAccess: 'Enabled'
  }
}

resource sqlDb 'Microsoft.Sql/servers/databases@2021-08-01-preview' = {
  name: sqlDatabaseName
  parent: sqlServer
  location: location
  sku: {
    name: 'GP_S_Gen5'
    tier: 'GeneralPurpose'
    family: 'Gen5'
    capacity: 2
  } 
}

resource sqlVnetRules 'Microsoft.Sql/servers/virtualNetworkRules@2021-08-01-preview' = {
  name: 'sqlVnetRule'
  parent: sqlServer
  properties: {
    virtualNetworkSubnetId: virtualNetwork.properties.subnets[0].id
    ignoreMissingVnetServiceEndpoint: false
  }
}

// Azure Storage Account
resource storageAccount 'Microsoft.Storage/storageAccounts@2021-08-01' = {
  name: storageAccountName
  location: location
  sku: {
    name: storageSku
  }
  kind: 'StorageV2'
  identity: {
    type: 'SystemAssigned'
  }

  resource blobServices 'blobServices' = {
    name: 'default'

    resource container 'containers' = {
      name: blobContainerName
    }
  }
}
