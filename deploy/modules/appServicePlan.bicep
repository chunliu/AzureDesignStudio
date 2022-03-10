@description('Name of the App Service Plan that will be deployed.')
param appServicePlanName string

@description('The SKU size for our App Service Plan')
param appServicePlanSKU string

@description('The capacity size for our App Service Plan')
param appServiceCapacityCount int

@description('Location to deploy the Azure resources too. Default is the location of the resource group')
param location string = resourceGroup().location

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

output appServicePlanId string = appServicePlan.id
