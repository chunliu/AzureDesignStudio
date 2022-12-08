// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Compute
{
    /// <summary>
    /// VMDiskSecurityProfile
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class VMDiskSecurityProfile
    {
        /// <summary>
        /// Specifies the EncryptionType of the managed disk. <br> It is set to DiskWithVMGuestState for encryption of the managed disk along with VMGuestState blob, and VMGuestStateOnly for encryption of just the VMGuestState blob. <br><br> NOTE: It can be set for only Confidential VMs.
        /// </summary>
        [JsonPropertyName("securityEncryptionType")]
        public string SecurityEncryptionType { get; set; }

        /// <summary>
        /// Specifies the customer managed disk encryption set resource id for the managed disk that is used for Customer Managed Key encrypted ConfidentialVM OS Disk and VMGuest blob.
        /// </summary>
        [JsonPropertyName("diskEncryptionSet")]
        public DiskEncryptionSetParameters DiskEncryptionSet { get; set; }
    }
}