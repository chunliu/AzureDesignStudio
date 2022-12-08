// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Compute
{
    /// <summary>
    /// StorageProfile
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class StorageProfile
    {
        /// <summary>
        /// Specifies information about the image to use. You can specify information about platform images, marketplace images, or virtual machine images. This element is required when you want to use a platform image, marketplace image, or virtual machine image, but is not used in other creation operations.
        /// </summary>
        [JsonPropertyName("imageReference")]
        public ImageReference ImageReference { get; set; }

        /// <summary>
        /// Specifies information about the operating system disk used by the virtual machine. <br><br> For more information about disks, see [About disks and VHDs for Azure virtual machines](https://docs.microsoft.com/azure/virtual-machines/managed-disks-overview).
        /// </summary>
        [JsonPropertyName("osDisk")]
        public OSDisk OsDisk { get; set; }

        /// <summary>
        /// Specifies the parameters that are used to add a data disk to a virtual machine. <br><br> For more information about disks, see [About disks and VHDs for Azure virtual machines](https://docs.microsoft.com/azure/virtual-machines/managed-disks-overview).
        /// </summary>
        [JsonPropertyName("dataDisks")]
        public IList<DataDisk> DataDisks { get; set; }

        /// <summary>
        /// Specifies the disk controller type configured for the VM. <br><br>NOTE: This property will be set to the default disk controller type if not specified provided virtual machine is being created as a hyperVGeneration: V2 based on the capabilities of the operating system disk and VM size from the the specified minimum api version. <br>You need to deallocate the VM before updating its disk controller type unless you are updating the VM size in the VM configuration which implicitly deallocates and reallocates the VM. <br><br> Minimum api-version: 2022-08-01
        /// </summary>
        [JsonPropertyName("diskControllerType")]
        public string DiskControllerType { get; set; }
    }
}