// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// RetentionPolicyParameters
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class RetentionPolicyParameters
    {
        /// <summary>
        /// Number of days to retain flow log records.
        /// </summary>
        [JsonPropertyName("days")]
        public int Days { get; set; }

        /// <summary>
        /// Flag to enable/disable retention.
        /// </summary>
        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }
    }
}