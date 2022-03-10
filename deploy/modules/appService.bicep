@description('Name of the App Service that will be deployed')
param appServiceName string

@description('Name of the container image in ACR')
param containerImage string

@description('Location to deploy the Azure resources too. Default is the location of the resource group')
param location string = resourceGroup().location

@description('The App Plan Id that the App Service will be deployed to')
param appServicePlanId string

@description('The container registry that this App Service will use')
param containerRegistryLoginServer string

@description('The Subnet Id that this App Service will use')
param subnetResourceId string

@description('The name of the ACR that will be deployed')
param acrName string

var acrPullRoleDefinitionId = subscriptionResourceId('Microsoft.Authorization/roleDefinitions', '7f951dda-4ed3-4680-a7ca-43fe172d538d')

resource containerRegistry 'Microsoft.ContainerRegistry/registries@2021-12-01-preview' existing = {
  name: acrName
}

resource appService 'Microsoft.Web/sites@2021-03-01' = {
  name: appServiceName
  location: location
  kind: 'app,linux,container'
  properties: {
    serverFarmId: appServicePlanId
    siteConfig: {
      appSettings: [
        {
          name: 'DOCKER_REGISTRY_SERVER_URL'
          value: 'https://${containerRegistryLoginServer}'
        }
      ]
      acrUseManagedIdentityCreds: true
      linuxFxVersion: 'DOCKER|${containerRegistryLoginServer}/${containerImage}'
      vnetRouteAllEnabled: true
      httpLoggingEnabled: true
      detailedErrorLoggingEnabled: true
      logsDirectorySizeLimit: 35
    }
  }
  identity: {
    type: 'SystemAssigned'
  }
}

resource siteProperties 'Microsoft.Web/sites/networkConfig@2021-03-01' = {
  name: 'virtualNetwork'
  parent: appService
  properties: {
    subnetResourceId: subnetResourceId
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
