// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Storage
{
    /// <summary>
    /// EncryptionServices
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class EncryptionServices
    {
        /// <summary>
        /// The encryption function of the blob storage service.
        /// </summary>
        [JsonPropertyName("blob")]
        public EncryptionService Blob { get; set; }

        /// <summary>
        /// The encryption function of the file storage service.
        /// </summary>
        [JsonPropertyName("file")]
        public EncryptionService File { get; set; }

        /// <summary>
        /// The encryption function of the table storage service.
        /// </summary>
        [JsonPropertyName("table")]
        public EncryptionService Table { get; set; }

        /// <summary>
        /// The encryption function of the queue storage service.
        /// </summary>
        [JsonPropertyName("queue")]
        public EncryptionService Queue { get; set; }
    }
}