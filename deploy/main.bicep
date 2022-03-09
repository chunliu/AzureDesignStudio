@description('The name of the ACR that will be deployed')
param acrName string

@description('The SKU size for the ACR')
param acrSKU string

@description('The username for the Azure Container Registry')
param acrUsername string

@description('The password for the Azure Container Registry')
param acrPassword string

@description('Name of the Log Analytcis workspace')
param logAnalyticsName string

@description('Name of the Container App environment')
param containerAppEnvironmentName string

@description('Name of the Container App')
param containerAppName string

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
@secure()
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

resource containerRegistry 'Microsoft.ContainerRegistry/registries@2021-12-01-preview' = {
  name: acrName
  location: location
  sku: {
    name: acrSKU
  }
  properties: {
    adminUserEnabled: true
  }
}

resource logAnalytics 'Microsoft.OperationalInsights/workspaces@2021-12-01-preview' = {
  name: logAnalyticsName
  location: location
  properties: {
    sku: {
      name: 'PerGB2018'
    }
  } 
}

resource containerAppEnvironment 'Microsoft.Web/kubeEnvironments@2021-03-01' = {
  name: containerAppEnvironmentName
  location: location
  kind: 'containerenvironment'
  properties: {
    environmentType: 'managed'
    internalLoadBalancerEnabled: false
    appLogsConfiguration: {
      logAnalyticsConfiguration: {
        customerId: logAnalytics.properties.customerId
        sharedKey: logAnalytics.listKeys().primarySharedKey
      }
    }
  }
}

// Change to Azure Container Apps
resource containerApp 'Microsoft.Web/containerApps@2021-03-01' = {
  name: containerAppName
  location: location 
  properties: {
    kubeEnvironmentId: containerAppEnvironment.id
    configuration: {
      ingress: {
        external: true
        targetPort: 80
        allowInsecure: false
        traffic: [
          {
            latestRevision: true
            weight: 100
          }
        ]
      }
      registries: [
        {
          server: containerRegistry.properties.loginServer
          username: acrUsername
          passwordSecretRef: 'container-registry-password'
        }
      ]
      secrets: [
        {
          name: 'container-registry-password'
          value: acrPassword
        }
      ]
    }
    template: {
      containers: [
        {
          name: containerAppName
          image: ''
          resources: {
            cpu: '0.5'
            memory: '1Gi'
          }
        }
      ]
      scale: {
        minReplicas: 1
        maxReplicas: 1
      }
    }
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
    name: 'Standard'
    tier: 'Standard'
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
}

resource blobContainer 'Microsoft.Storage/storageAccounts/blobServices/containers@2021-08-01' = {
  name: blobContainerName
}
