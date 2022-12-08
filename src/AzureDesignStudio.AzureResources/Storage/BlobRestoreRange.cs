// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Storage
{
    /// <summary>
    /// BlobRestoreRange
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class BlobRestoreRange
    {
        /// <summary>
        /// Blob start range. This is inclusive. Empty means account start.
        /// </summary>
        [Required]
        [JsonPropertyName("startRange")]
        public string StartRange { get; set; }

        /// <summary>
        /// Blob end range. This is exclusive. Empty means account end.
        /// </summary>
        [Required]
        [JsonPropertyName("endRange")]
        public string EndRange { get; set; }
    }
}