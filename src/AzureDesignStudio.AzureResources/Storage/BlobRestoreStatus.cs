// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Storage
{
    /// <summary>
    /// BlobRestoreStatus
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class BlobRestoreStatus
    {
        /// <summary>
        /// The status of blob restore progress. Possible values are: - InProgress: Indicates that blob restore is ongoing. - Complete: Indicates that blob restore has been completed successfully. - Failed: Indicates that blob restore is failed.
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        /// Failure reason when blob restore is failed.
        /// </summary>
        [JsonPropertyName("failureReason")]
        public string FailureReason { get; set; }

        /// <summary>
        /// Id for tracking blob restore request.
        /// </summary>
        [JsonPropertyName("restoreId")]
        public string RestoreId { get; set; }

        /// <summary>
        /// Blob restore request parameters.
        /// </summary>
        [JsonPropertyName("parameters")]
        public BlobRestoreParameters Parameters { get; set; }
    }
}