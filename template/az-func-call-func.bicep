param swa_name string = 'swa-az-func-call-func'

var sku = {
  name: 'Standard'
  tier: 'Standard'
}

var properties = {
  stagingEnvironmentPolicy: 'Enabled'
  allowConfigFileUpdates: true
}


resource swa_resource 'Microsoft.Web/staticSites@2021-02-01' = {
  name: swa_name
  location: 'eastus2'
  sku: sku
  properties: properties
}
