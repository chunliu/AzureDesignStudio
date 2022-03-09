@description('The name of the ACR that will be deployed')
param acrName string

@description('The SKU size for the ACR')
param acrSku string

@description('Name of the App Service Plan that will be deployed.')
param appServicePlanName string

@description('The SKU size for our App Service Plan')
param appServicePlanSKU string

@description('The capacity size for our App Service Plan')
param appServiceCapacityCount int

@description('Name of the App Service that will be deployed')
param appServiceName string

@description('The name of the Virtual Network')
param virutalNetworkName string

@description('The name of the subnet in the vNET')
param subnetName string

@description('Name of the App Insights Instance')
param appInsightsName string

@description('Name of the Azure Key Vault')
param keyVaultName string

@description('The SKU size of the Azure Key Vault')
param keyVaultSku string

@description('Name of the SQL Server')
param sqlServerName string

@description('The admin username for the SQL Server')
param sqlAdminLogin string

@description('The admin password for the SQL Server')
param sqlAdminPassword string

@description('Name of the SQL Database')
param sqlDatabaseName string

@description('The name of the Azure Storage Account')
param storageAccountName string

@description('The SKU size of the Storage Account')
param storageSku string

@description('Name of the blob container')
param blobContainerName string

@description('Location to deploy the Azure resources too. Default is the location of the resource group')
param location string = resourceGroup().location

var acrPullRoleDefinitionId = subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '7f951dda-4ed3-4680-a7ca-43fe172d538d')

resource containerRegistry 'Microsoft.ContainerRegistry/registries@2021-12-01-preview' = {
  name: acrName
  location: location
  sku: {
    name: acrSku
  }
  identity: {
    type: 'SystemAssigned'
  }
}

resource appServicePlan 'Microsoft.Web/serverfarms@2021-03-01' = {
  name: appServicePlanName
  location: location
  sku: {
    name: appServicePlanSKU
    capacity: appServiceCapacityCount
  }
  kind: 'linux'
  properties: {
    reserved: true
  }
}

resource appService 'Microsoft.Web/sites@2021-03-01' = {
  name: appServiceName
  location: location
  kind: 'app,linux,container'
  properties: {
    serverFarmId: appServicePlan.id
    siteConfig: {
      appSettings: [

      ]
      acrUseManagedIdentityCreds: true
      linuxFxVersion: 'DOCKER|${containerRegistry.properties.loginServer}'
    }
  }
  identity: {
    type: 'SystemAssigned'
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

// Azure Key Vault
resource keyVault 'Microsoft.KeyVault/vaults@2021-11-01-preview' = {
  name: keyVaultName
  location: location
  properties: {
    sku: {
      family: 'A'
      name: keyVaultSku
    }
    tenantId: subscription().tenantId
    accessPolicies: [
      
    ]
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

resource appServiceAcrPullRoleAssignment 'Microsoft.Authorization/roleAssignments@2020-10-01-preview' = {
  name: guid(containerRegistry.id, appService.id, acrPullRoleDefinitionId)
  properties: {
    principalId: appService.identity.principalId
    roleDefinitionId: acrPullRoleDefinitionId
    principalType: 'ServicePrincipal'
  }
}
