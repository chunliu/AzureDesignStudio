// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// FirewallPolicyLogAnalyticsResources
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class FirewallPolicyLogAnalyticsResources
    {
        /// <summary>
        /// List of workspaces for Firewall Policy Insights.
        /// </summary>
        [JsonPropertyName("workspaces")]
        public IList<FirewallPolicyLogAnalyticsWorkspace> Workspaces { get; set; }

        /// <summary>
        /// The default workspace Id for Firewall Policy Insights.
        /// </summary>
        [JsonPropertyName("defaultWorkspaceId")]
        public SubResource DefaultWorkspaceId { get; set; }
    }
}