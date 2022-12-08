// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// FirewallPolicyPropertiesFormat
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class FirewallPolicyPropertiesFormat
    {
        /// <summary>
        /// List of references to FirewallPolicyRuleCollectionGroups.
        /// </summary>
        [JsonPropertyName("ruleCollectionGroups")]
        public IList<SubResource> RuleCollectionGroups { get; set; }

        /// <summary>
        /// The provisioning state of the firewall policy resource.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }

        /// <summary>
        /// The parent firewall policy from which rules are inherited.
        /// </summary>
        [JsonPropertyName("basePolicy")]
        public SubResource BasePolicy { get; set; }

        /// <summary>
        /// List of references to Azure Firewalls that this Firewall Policy is associated with.
        /// </summary>
        [JsonPropertyName("firewalls")]
        public IList<SubResource> Firewalls { get; set; }

        /// <summary>
        /// List of references to Child Firewall Policies.
        /// </summary>
        [JsonPropertyName("childPolicies")]
        public IList<SubResource> ChildPolicies { get; set; }

        /// <summary>
        /// The operation mode for Threat Intelligence.
        /// </summary>
        [JsonPropertyName("threatIntelMode")]
        public string ThreatIntelMode { get; set; }

        /// <summary>
        /// ThreatIntel Whitelist for Firewall Policy.
        /// </summary>
        [JsonPropertyName("threatIntelWhitelist")]
        public FirewallPolicyThreatIntelWhitelist ThreatIntelWhitelist { get; set; }

        /// <summary>
        /// Insights on Firewall Policy.
        /// </summary>
        [JsonPropertyName("insights")]
        public FirewallPolicyInsights Insights { get; set; }

        /// <summary>
        /// The private IP addresses/IP ranges to which traffic will not be SNAT.
        /// </summary>
        [JsonPropertyName("snat")]
        public FirewallPolicySnat Snat { get; set; }

        /// <summary>
        /// SQL Settings definition.
        /// </summary>
        [JsonPropertyName("sql")]
        public FirewallPolicySQL Sql { get; set; }

        /// <summary>
        /// DNS Proxy Settings definition.
        /// </summary>
        [JsonPropertyName("dnsSettings")]
        public DnsSettings DnsSettings { get; set; }

        /// <summary>
        /// Explicit Proxy Settings definition.
        /// </summary>
        [JsonPropertyName("explicitProxy")]
        public ExplicitProxy ExplicitProxy { get; set; }

        /// <summary>
        /// The configuration for Intrusion detection.
        /// </summary>
        [JsonPropertyName("intrusionDetection")]
        public FirewallPolicyIntrusionDetection IntrusionDetection { get; set; }

        /// <summary>
        /// TLS Configuration definition.
        /// </summary>
        [JsonPropertyName("transportSecurity")]
        public FirewallPolicyTransportSecurity TransportSecurity { get; set; }

        /// <summary>
        /// The Firewall Policy SKU.
        /// </summary>
        [JsonPropertyName("sku")]
        public FirewallPolicySku Sku { get; set; }
    }
}