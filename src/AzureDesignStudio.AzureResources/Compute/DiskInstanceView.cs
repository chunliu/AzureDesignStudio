// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Compute
{
    /// <summary>
    /// DiskInstanceView
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class DiskInstanceView
    {
        /// <summary>
        /// The disk name.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Specifies the encryption settings for the OS Disk. <br><br> Minimum api-version: 2015-06-15
        /// </summary>
        [JsonPropertyName("encryptionSettings")]
        public IList<DiskEncryptionSettings> EncryptionSettings { get; set; }

        /// <summary>
        /// The resource status information.
        /// </summary>
        [JsonPropertyName("statuses")]
        public IList<InstanceViewStatus> Statuses { get; set; }
    }
}