// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// NetworkInterfaceTapConfigurationPropertiesFormat
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class NetworkInterfaceTapConfigurationPropertiesFormat
    {
        /// <summary>
        /// The reference to the Virtual Network Tap resource.
        /// </summary>
        [JsonPropertyName("virtualNetworkTap")]
        public VirtualNetworkTap VirtualNetworkTap { get; set; }

        /// <summary>
        /// The provisioning state of the network interface tap configuration resource.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }
    }
}