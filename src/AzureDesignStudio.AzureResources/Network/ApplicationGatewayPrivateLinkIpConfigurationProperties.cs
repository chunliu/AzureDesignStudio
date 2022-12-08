// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// ApplicationGatewayPrivateLinkIpConfigurationProperties
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ApplicationGatewayPrivateLinkIpConfigurationProperties
    {
        /// <summary>
        /// The private IP address of the IP configuration.
        /// </summary>
        [JsonPropertyName("privateIPAddress")]
        public string PrivateIPAddress { get; set; }

        /// <summary>
        /// The private IP address allocation method.
        /// </summary>
        [JsonPropertyName("privateIPAllocationMethod")]
        public string PrivateIPAllocationMethod { get; set; }

        /// <summary>
        /// Reference to the subnet resource.
        /// </summary>
        [JsonPropertyName("subnet")]
        public SubResource Subnet { get; set; }

        /// <summary>
        /// Whether the ip configuration is primary or not.
        /// </summary>
        [JsonPropertyName("primary")]
        public bool Primary { get; set; }

        /// <summary>
        /// The provisioning state of the application gateway private link IP configuration.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }
    }
}