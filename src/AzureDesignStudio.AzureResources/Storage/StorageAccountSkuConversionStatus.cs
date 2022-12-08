// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Storage
{
    /// <summary>
    /// StorageAccountSkuConversionStatus
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class StorageAccountSkuConversionStatus
    {
        /// <summary>
        /// This property indicates the current sku conversion status.
        /// </summary>
        [JsonPropertyName("skuConversionStatus")]
        public string SkuConversionStatus { get; set; }

        /// <summary>
        /// This property represents the target sku name to which the account sku is being converted asynchronously.
        /// </summary>
        [JsonPropertyName("targetSkuName")]
        public string TargetSkuName { get; set; }

        /// <summary>
        /// This property represents the sku conversion start time.
        /// </summary>
        [JsonPropertyName("startTime")]
        public string StartTime { get; set; }

        /// <summary>
        /// This property represents the sku conversion end time.
        /// </summary>
        [JsonPropertyName("endTime")]
        public string EndTime { get; set; }
    }
}