// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// AzureFirewallIPConfigurationPropertiesFormat
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class AzureFirewallIPConfigurationPropertiesFormat
    {
        /// <summary>
        /// The Firewall Internal Load Balancer IP to be used as the next hop in User Defined Routes.
        /// </summary>
        [JsonPropertyName("privateIPAddress")]
        public string PrivateIPAddress { get; set; }

        /// <summary>
        /// Reference to the subnet resource. This resource must be named 'AzureFirewallSubnet' or 'AzureFirewallManagementSubnet'.
        /// </summary>
        [JsonPropertyName("subnet")]
        public SubResource Subnet { get; set; }

        /// <summary>
        /// Reference to the PublicIP resource. This field is a mandatory input if subnet is not null.
        /// </summary>
        [JsonPropertyName("publicIPAddress")]
        public SubResource PublicIPAddress { get; set; }

        /// <summary>
        /// The provisioning state of the Azure firewall IP configuration resource.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }
    }
}