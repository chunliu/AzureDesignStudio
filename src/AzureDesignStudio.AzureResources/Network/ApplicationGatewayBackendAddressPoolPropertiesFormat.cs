// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// ApplicationGatewayBackendAddressPoolPropertiesFormat
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ApplicationGatewayBackendAddressPoolPropertiesFormat
    {
        /// <summary>
        /// Collection of references to IPs defined in network interfaces.
        /// </summary>
        [JsonPropertyName("backendIPConfigurations")]
        public IList<NetworkInterfaceIPConfiguration> BackendIPConfigurations { get; set; }

        /// <summary>
        /// Backend addresses.
        /// </summary>
        [JsonPropertyName("backendAddresses")]
        public IList<ApplicationGatewayBackendAddress> BackendAddresses { get; set; }

        /// <summary>
        /// The provisioning state of the backend address pool resource.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }
    }
}