// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// FirewallPolicyIntrusionDetectionBypassTrafficSpecifications
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class FirewallPolicyIntrusionDetectionBypassTrafficSpecifications
    {
        /// <summary>
        /// Name of the bypass traffic rule.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Description of the bypass traffic rule.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// The rule bypass protocol.
        /// </summary>
        [JsonPropertyName("protocol")]
        public string Protocol { get; set; }

        /// <summary>
        /// List of source IP addresses or ranges for this rule.
        /// </summary>
        [JsonPropertyName("sourceAddresses")]
        public IList<string> SourceAddresses { get; set; }

        /// <summary>
        /// List of destination IP addresses or ranges for this rule.
        /// </summary>
        [JsonPropertyName("destinationAddresses")]
        public IList<string> DestinationAddresses { get; set; }

        /// <summary>
        /// List of destination ports or ranges.
        /// </summary>
        [JsonPropertyName("destinationPorts")]
        public IList<string> DestinationPorts { get; set; }

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