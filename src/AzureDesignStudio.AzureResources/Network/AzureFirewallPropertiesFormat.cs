// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// AzureFirewallPropertiesFormat
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class AzureFirewallPropertiesFormat
    {
        /// <summary>
        /// Collection of application rule collections used by Azure Firewall.
        /// </summary>
        [JsonPropertyName("applicationRuleCollections")]
        public IList<AzureFirewallApplicationRuleCollection> ApplicationRuleCollections { get; set; }

        /// <summary>
        /// Collection of NAT rule collections used by Azure Firewall.
        /// </summary>
        [JsonPropertyName("natRuleCollections")]
        public IList<AzureFirewallNatRuleCollection> NatRuleCollections { get; set; }

        /// <summary>
        /// Collection of network rule collections used by Azure Firewall.
        /// </summary>
        [JsonPropertyName("networkRuleCollections")]
        public IList<AzureFirewallNetworkRuleCollection> NetworkRuleCollections { get; set; }

        /// <summary>
        /// IP configuration of the Azure Firewall resource.
        /// </summary>
        [JsonPropertyName("ipConfigurations")]
        public IList<AzureFirewallIPConfiguration> IpConfigurations { get; set; }

        /// <summary>
        /// IP configuration of the Azure Firewall used for management traffic.
        /// </summary>
        [JsonPropertyName("managementIpConfiguration")]
        public AzureFirewallIPConfiguration ManagementIpConfiguration { get; set; }

        /// <summary>
        /// The provisioning state of the Azure firewall resource.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }

        /// <summary>
        /// The operation mode for Threat Intelligence.
        /// </summary>
        [JsonPropertyName("threatIntelMode")]
        public string ThreatIntelMode { get; set; }

        /// <summary>
        /// The virtualHub to which the firewall belongs.
        /// </summary>
        [JsonPropertyName("virtualHub")]
        public SubResource VirtualHub { get; set; }

        /// <summary>
        /// The firewallPolicy associated with this azure firewall.
        /// </summary>
        [JsonPropertyName("firewallPolicy")]
        public SubResource FirewallPolicy { get; set; }

        /// <summary>
        /// IP addresses associated with AzureFirewall.
        /// </summary>
        [JsonPropertyName("hubIPAddresses")]
        public HubIPAddresses HubIPAddresses { get; set; }

        /// <summary>
        /// IpGroups associated with AzureFirewall.
        /// </summary>
        [JsonPropertyName("ipGroups")]
        public IList<AzureFirewallIpGroups> IpGroups { get; set; }

        /// <summary>
        /// The Azure Firewall Resource SKU.
        /// </summary>
        [JsonPropertyName("sku")]
        public AzureFirewallSku Sku { get; set; }

        /// <summary>
        /// The additional properties used to further config this azure firewall.
        /// </summary>
        [JsonPropertyName("additionalProperties")]
        public AzureFirewallAdditionalProperties AdditionalProperties { get; set; }
    }
}