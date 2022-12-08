// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// SecurityRulePropertiesFormat
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class SecurityRulePropertiesFormat
    {
        /// <summary>
        /// A description for this rule. Restricted to 140 chars.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// Network protocol this rule applies to.
        /// </summary>
        [Required]
        [JsonPropertyName("protocol")]
        public string Protocol { get; set; }

        /// <summary>
        /// The source port or range. Integer or range between 0 and 65535. Asterisk '*' can also be used to match all ports.
        /// </summary>
        [JsonPropertyName("sourcePortRange")]
        public string SourcePortRange { get; set; }

        /// <summary>
        /// The destination port or range. Integer or range between 0 and 65535. Asterisk '*' can also be used to match all ports.
        /// </summary>
        [JsonPropertyName("destinationPortRange")]
        public string DestinationPortRange { get; set; }

        /// <summary>
        /// The CIDR or source IP range. Asterisk '*' can also be used to match all source IPs. Default tags such as 'VirtualNetwork', 'AzureLoadBalancer' and 'Internet' can also be used. If this is an ingress rule, specifies where network traffic originates from.
        /// </summary>
        [JsonPropertyName("sourceAddressPrefix")]
        public string SourceAddressPrefix { get; set; }

        /// <summary>
        /// The CIDR or source IP ranges.
        /// </summary>
        [JsonPropertyName("sourceAddressPrefixes")]
        public IList<string> SourceAddressPrefixes { get; set; }

        /// <summary>
        /// The application security group specified as source.
        /// </summary>
        [JsonPropertyName("sourceApplicationSecurityGroups")]
        public IList<ApplicationSecurityGroup> SourceApplicationSecurityGroups { get; set; }

        /// <summary>
        /// The destination address prefix. CIDR or destination IP range. Asterisk '*' can also be used to match all source IPs. Default tags such as 'VirtualNetwork', 'AzureLoadBalancer' and 'Internet' can also be used.
        /// </summary>
        [JsonPropertyName("destinationAddressPrefix")]
        public string DestinationAddressPrefix { get; set; }

        /// <summary>
        /// The destination address prefixes. CIDR or destination IP ranges.
        /// </summary>
        [JsonPropertyName("destinationAddressPrefixes")]
        public IList<string> DestinationAddressPrefixes { get; set; }

        /// <summary>
        /// The application security group specified as destination.
        /// </summary>
        [JsonPropertyName("destinationApplicationSecurityGroups")]
        public IList<ApplicationSecurityGroup> DestinationApplicationSecurityGroups { get; set; }

        /// <summary>
        /// The source port ranges.
        /// </summary>
        [JsonPropertyName("sourcePortRanges")]
        public IList<string> SourcePortRanges { get; set; }

        /// <summary>
        /// The destination port ranges.
        /// </summary>
        [JsonPropertyName("destinationPortRanges")]
        public IList<string> DestinationPortRanges { get; set; }

        /// <summary>
        /// The network traffic is allowed or denied.
        /// </summary>
        [Required]
        [JsonPropertyName("access")]
        public string Access { get; set; }

        /// <summary>
        /// The priority of the rule. The value can be between 100 and 4096. The priority number must be unique for each rule in the collection. The lower the priority number, the higher the priority of the rule.
        /// </summary>
        [JsonPropertyName("priority")]
        public int Priority { get; set; }

        /// <summary>
        /// The direction of the rule. The direction specifies if rule will be evaluated on incoming or outgoing traffic.
        /// </summary>
        [Required]
        [JsonPropertyName("direction")]
        public string Direction { get; set; }

        /// <summary>
        /// The provisioning state of the security rule resource.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }
    }
}