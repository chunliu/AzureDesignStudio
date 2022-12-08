// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// AzureFirewallApplicationRule
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class AzureFirewallApplicationRule
    {
        /// <summary>
        /// Name of the application rule.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Description of the rule.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// List of source IP addresses for this rule.
        /// </summary>
        [JsonPropertyName("sourceAddresses")]
        public IList<string> SourceAddresses { get; set; }

        /// <summary>
        /// Array of ApplicationRuleProtocols.
        /// </summary>
        [JsonPropertyName("protocols")]
        public IList<AzureFirewallApplicationRuleProtocol> Protocols { get; set; }

        /// <summary>
        /// List of FQDNs for this rule.
        /// </summary>
        [JsonPropertyName("targetFqdns")]
        public IList<string> TargetFqdns { get; set; }

        /// <summary>
        /// List of FQDN Tags for this rule.
        /// </summary>
        [JsonPropertyName("fqdnTags")]
        public IList<string> FqdnTags { get; set; }

        /// <summary>
        /// List of source IpGroups for this rule.
        /// </summary>
        [JsonPropertyName("sourceIpGroups")]
        public IList<string> SourceIpGroups { get; set; }
    }
}