// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// TrafficAnalyticsProperties
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class TrafficAnalyticsProperties
    {
        /// <summary>
        /// Parameters that define the configuration of traffic analytics.
        /// </summary>
        [JsonPropertyName("networkWatcherFlowAnalyticsConfiguration")]
        public TrafficAnalyticsConfigurationProperties NetworkWatcherFlowAnalyticsConfiguration { get; set; }
    }
}