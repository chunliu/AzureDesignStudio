// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Web
{
    /// <summary>
    /// SlotSwapStatus
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class SlotSwapStatus
    {
        /// <summary>
        /// The time the last successful slot swap completed.
        /// </summary>
        [JsonPropertyName("timestampUtc")]
        public string TimestampUtc { get; set; }

        /// <summary>
        /// The source slot of the last swap operation.
        /// </summary>
        [JsonPropertyName("sourceSlotName")]
        public string SourceSlotName { get; set; }

        /// <summary>
        /// The destination slot of the last swap operation.
        /// </summary>
        [JsonPropertyName("destinationSlotName")]
        public string DestinationSlotName { get; set; }
    }
}