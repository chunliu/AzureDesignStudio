// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// FlowLogPropertiesFormat
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class FlowLogPropertiesFormat
    {
        /// <summary>
        /// ID of network security group to which flow log will be applied.
        /// </summary>
        [Required]
        [JsonPropertyName("targetResourceId")]
        public string TargetResourceId { get; set; }

        /// <summary>
        /// Guid of network security group to which flow log will be applied.
        /// </summary>
        [JsonPropertyName("targetResourceGuid")]
        public string TargetResourceGuid { get; set; }

        /// <summary>
        /// ID of the storage account which is used to store the flow log.
        /// </summary>
        [Required]
        [JsonPropertyName("storageId")]
        public string StorageId { get; set; }

        /// <summary>
        /// Flag to enable/disable flow logging.
        /// </summary>
        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }

        /// <summary>
        /// Parameters that define the retention policy for flow log.
        /// </summary>
        [JsonPropertyName("retentionPolicy")]
        public RetentionPolicyParameters RetentionPolicy { get; set; }

        /// <summary>
        /// Parameters that define the flow log format.
        /// </summary>
        [JsonPropertyName("format")]
        public FlowLogFormatParameters Format { get; set; }

        /// <summary>
        /// Parameters that define the configuration of traffic analytics.
        /// </summary>
        [JsonPropertyName("flowAnalyticsConfiguration")]
        public TrafficAnalyticsProperties FlowAnalyticsConfiguration { get; set; }

        /// <summary>
        /// The provisioning state of the flow log.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }
    }
}