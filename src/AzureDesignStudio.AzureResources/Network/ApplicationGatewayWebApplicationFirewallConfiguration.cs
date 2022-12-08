// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// ApplicationGatewayWebApplicationFirewallConfiguration
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ApplicationGatewayWebApplicationFirewallConfiguration
    {
        /// <summary>
        /// Whether the web application firewall is enabled or not.
        /// </summary>
        [Required]
        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }

        /// <summary>
        /// Web application firewall mode.
        /// </summary>
        [Required]
        [JsonPropertyName("firewallMode")]
        public string FirewallMode { get; set; }

        /// <summary>
        /// The type of the web application firewall rule set. Possible values are: 'OWASP'.
        /// </summary>
        [Required]
        [JsonPropertyName("ruleSetType")]
        public string RuleSetType { get; set; }

        /// <summary>
        /// The version of the rule set type.
        /// </summary>
        [Required]
        [JsonPropertyName("ruleSetVersion")]
        public string RuleSetVersion { get; set; }

        /// <summary>
        /// The disabled rule groups.
        /// </summary>
        [JsonPropertyName("disabledRuleGroups")]
        public IList<ApplicationGatewayFirewallDisabledRuleGroup> DisabledRuleGroups { get; set; }

        /// <summary>
        /// Whether allow WAF to check request Body.
        /// </summary>
        [JsonPropertyName("requestBodyCheck")]
        public bool RequestBodyCheck { get; set; }

        /// <summary>
        /// Maximum request body size for WAF.
        /// </summary>
        [JsonPropertyName("maxRequestBodySize")]
        public int MaxRequestBodySize { get; set; }

        /// <summary>
        /// Maximum request body size in Kb for WAF.
        /// </summary>
        [JsonPropertyName("maxRequestBodySizeInKb")]
        public int MaxRequestBodySizeInKb { get; set; }

        /// <summary>
        /// Maximum file upload size in Mb for WAF.
        /// </summary>
        [JsonPropertyName("fileUploadLimitInMb")]
        public int FileUploadLimitInMb { get; set; }

        /// <summary>
        /// The exclusion list.
        /// </summary>
        [JsonPropertyName("exclusions")]
        public IList<ApplicationGatewayFirewallExclusion> Exclusions { get; set; }
    }
}