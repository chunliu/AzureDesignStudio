// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// TrafficAnalyticsConfigurationProperties
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class TrafficAnalyticsConfigurationProperties
    {
        /// <summary>
        /// Flag to enable/disable traffic analytics.
        /// </summary>
        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }

        /// <summary>
        /// The resource guid of the attached workspace.
        /// </summary>
        [JsonPropertyName("workspaceId")]
        public string WorkspaceId { get; set; }

        /// <summary>
        /// The location of the attached workspace.
        /// </summary>
        [JsonPropertyName("workspaceRegion")]
        public string WorkspaceRegion { get; set; }

        /// <summary>
        /// Resource Id of the attached workspace.
        /// </summary>
        [JsonPropertyName("workspaceResourceId")]
        public string WorkspaceResourceId { get; set; }

        /// <summary>
        /// The interval in minutes which would decide how frequently TA service should do flow analytics.
        /// </summary>
        [JsonPropertyName("trafficAnalyticsInterval")]
        public int TrafficAnalyticsInterval { get; set; }
    }
}