// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// FirewallPolicyLogAnalyticsWorkspace
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class FirewallPolicyLogAnalyticsWorkspace
    {
        /// <summary>
        /// Region to configure the Workspace.
        /// </summary>
        [JsonPropertyName("region")]
        public string Region { get; set; }

        /// <summary>
        /// The workspace Id for Firewall Policy Insights.
        /// </summary>
        [JsonPropertyName("workspaceId")]
        public SubResource WorkspaceId { get; set; }
    }
}