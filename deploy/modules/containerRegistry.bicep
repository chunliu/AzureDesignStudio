@description('The name of the ACR that will be deployed')
param acrName string

@description('The SKU size for the ACR')
param acrSku string = 'Basic'

@description('Location to deploy the ACR registry. Default set to resource group location.')
param location string = resourceGroup().location

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

output loginServer string = containerRegistry.properties.loginServer
output containerRegistryId string = containerRegistry.id
