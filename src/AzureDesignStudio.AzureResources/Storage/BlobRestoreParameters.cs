// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Storage
{
    /// <summary>
    /// BlobRestoreParameters
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class BlobRestoreParameters
    {
        /// <summary>
        /// Restore blob to the specified time.
        /// </summary>
        [Required]
        [JsonPropertyName("timeToRestore")]
        public string TimeToRestore { get; set; }

        /// <summary>
        /// Blob ranges to restore.
        /// </summary>
        [Required]
        [JsonPropertyName("blobRanges")]
        public IList<BlobRestoreRange> BlobRanges { get; set; }
    }
}