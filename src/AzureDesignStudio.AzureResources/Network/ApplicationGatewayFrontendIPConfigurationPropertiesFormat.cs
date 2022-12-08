// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// ApplicationGatewayFrontendIPConfigurationPropertiesFormat
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ApplicationGatewayFrontendIPConfigurationPropertiesFormat
    {
        /// <summary>
        /// PrivateIPAddress of the network interface IP Configuration.
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
        /// Reference to the PublicIP resource.
        /// </summary>
        [JsonPropertyName("publicIPAddress")]
        public SubResource PublicIPAddress { get; set; }

        /// <summary>
        /// Reference to the application gateway private link configuration.
        /// </summary>
        [JsonPropertyName("privateLinkConfiguration")]
        public SubResource PrivateLinkConfiguration { get; set; }

        /// <summary>
        /// The provisioning state of the frontend IP configuration resource.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }
    }
}