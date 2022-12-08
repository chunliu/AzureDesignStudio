// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Compute
{
    /// <summary>
    /// ManagedDiskParameters
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ManagedDiskParameters
    {
        /// <summary>
        /// Specifies the storage account type for the managed disk. NOTE: UltraSSD_LRS can only be used with data disks, it cannot be used with OS Disk.
        /// </summary>
        [JsonPropertyName("storageAccountType")]
        public string StorageAccountType { get; set; }

        /// <summary>
        /// Specifies the customer managed disk encryption set resource id for the managed disk.
        /// </summary>
        [JsonPropertyName("diskEncryptionSet")]
        public DiskEncryptionSetParameters DiskEncryptionSet { get; set; }

        /// <summary>
        /// Specifies the security profile for the managed disk.
        /// </summary>
        [JsonPropertyName("securityProfile")]
        public VMDiskSecurityProfile SecurityProfile { get; set; }

        /// <summary>
        /// Resource Id
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}