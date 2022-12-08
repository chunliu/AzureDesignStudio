// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// FirewallPolicyInsights
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class FirewallPolicyInsights
    {
        /// <summary>
        /// A flag to indicate if the insights are enabled on the policy.
        /// </summary>
        [JsonPropertyName("isEnabled")]
        public bool IsEnabled { get; set; }

        /// <summary>
        /// Number of days the insights should be enabled on the policy.
        /// </summary>
        [JsonPropertyName("retentionDays")]
        public int RetentionDays { get; set; }

        /// <summary>
        /// Workspaces needed to configure the Firewall Policy Insights.
        /// </summary>
        [JsonPropertyName("logAnalyticsResources")]
        public FirewallPolicyLogAnalyticsResources LogAnalyticsResources { get; set; }
    }
}