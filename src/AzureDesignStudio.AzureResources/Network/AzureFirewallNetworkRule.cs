// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// AzureFirewallNetworkRule
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class AzureFirewallNetworkRule
    {
        /// <summary>
        /// Name of the network rule.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Description of the rule.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// Array of AzureFirewallNetworkRuleProtocols.
        /// </summary>
        [JsonPropertyName("protocols")]
        public IList<string> Protocols { get; set; }

        /// <summary>
        /// List of source IP addresses for this rule.
        /// </summary>
        [JsonPropertyName("sourceAddresses")]
        public IList<string> SourceAddresses { get; set; }

        /// <summary>
        /// List of destination IP addresses.
        /// </summary>
        [JsonPropertyName("destinationAddresses")]
        public IList<string> DestinationAddresses { get; set; }

        /// <summary>
        /// List of destination ports.
        /// </summary>
        [JsonPropertyName("destinationPorts")]
        public IList<string> DestinationPorts { get; set; }

        /// <summary>
        /// List of destination FQDNs.
        /// </summary>
        [JsonPropertyName("destinationFqdns")]
        public IList<string> DestinationFqdns { get; set; }

        /// <summary>
        /// List of source IpGroups for this rule.
        /// </summary>
        [JsonPropertyName("sourceIpGroups")]
        public IList<string> SourceIpGroups { get; set; }

        /// <summary>
        /// List of destination IpGroups for this rule.
        /// </summary>
        [JsonPropertyName("destinationIpGroups")]
        public IList<string> DestinationIpGroups { get; set; }
    }
}