// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Compute
{
    /// <summary>
    /// DataDisk
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class DataDisk
    {
        /// <summary>
        /// Specifies the logical unit number of the data disk. This value is used to identify data disks within the VM and therefore must be unique for each data disk attached to a VM.
        /// </summary>
        [Required]
        [JsonPropertyName("lun")]
        public int Lun { get; set; }

        /// <summary>
        /// The disk name.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The virtual hard disk.
        /// </summary>
        [JsonPropertyName("vhd")]
        public VirtualHardDisk Vhd { get; set; }

        /// <summary>
        /// The source user image virtual hard disk. The virtual hard disk will be copied before being attached to the virtual machine. If SourceImage is provided, the destination virtual hard drive must not exist.
        /// </summary>
        [JsonPropertyName("image")]
        public VirtualHardDisk Image { get; set; }

        /// <summary>
        /// Specifies the caching requirements. <br><br> Possible values are: <br><br> **None** <br><br> **ReadOnly** <br><br> **ReadWrite** <br><br> Default: **None for Standard storage. ReadOnly for Premium storage**
        /// </summary>
        [JsonPropertyName("caching")]
        public string Caching { get; set; }

        /// <summary>
        /// Specifies whether writeAccelerator should be enabled or disabled on the disk.
        /// </summary>
        [JsonPropertyName("writeAcceleratorEnabled")]
        public bool WriteAcceleratorEnabled { get; set; }

        /// <summary>
        /// Specifies how the virtual machine should be created.<br><br> Possible values are:<br><br> **Attach** \u2013 This value is used when you are using a specialized disk to create the virtual machine.<br><br> **FromImage** \u2013 This value is used when you are using an image to create the virtual machine. If you are using a platform image, you also use the imageReference element described above. If you are using a marketplace image, you  also use the plan element previously described.
        /// </summary>
        [Required]
        [JsonPropertyName("createOption")]
        public string CreateOption { get; set; }

        /// <summary>
        /// Specifies the size of an empty data disk in gigabytes. This element can be used to overwrite the size of the disk in a virtual machine image. <br><br> diskSizeGB is the number of bytes x 1024^3 for the disk and the value cannot be larger than 1023
        /// </summary>
        [JsonPropertyName("diskSizeGB")]
        public int DiskSizeGB { get; set; }

        /// <summary>
        /// The managed disk parameters.
        /// </summary>
        [JsonPropertyName("managedDisk")]
        public ManagedDiskParameters ManagedDisk { get; set; }

        /// <summary>
        /// Specifies whether the data disk is in process of detachment from the VirtualMachine/VirtualMachineScaleset
        /// </summary>
        [JsonPropertyName("toBeDetached")]
        public bool ToBeDetached { get; set; }

        /// <summary>
        /// Specifies the Read-Write IOPS for the managed disk when StorageAccountType is UltraSSD_LRS. Returned only for VirtualMachine ScaleSet VM disks. Can be updated only via updates to the VirtualMachine Scale Set.
        /// </summary>
        [JsonPropertyName("diskIOPSReadWrite")]
        public int DiskIOPSReadWrite { get; set; }

        /// <summary>
        /// Specifies the bandwidth in MB per second for the managed disk when StorageAccountType is UltraSSD_LRS. Returned only for VirtualMachine ScaleSet VM disks. Can be updated only via updates to the VirtualMachine Scale Set.
        /// </summary>
        [JsonPropertyName("diskMBpsReadWrite")]
        public int DiskMBpsReadWrite { get; set; }

        /// <summary>
        /// Specifies the detach behavior to be used while detaching a disk or which is already in the process of detachment from the virtual machine. Supported values: **ForceDetach**. <br><br> detachOption: **ForceDetach** is applicable only for managed data disks. If a previous detachment attempt of the data disk did not complete due to an unexpected failure from the virtual machine and the disk is still not released then use force-detach as a last resort option to detach the disk forcibly from the VM. All writes might not have been flushed when using this detach behavior. <br><br> This feature is still in preview mode and is not supported for VirtualMachineScaleSet. To force-detach a data disk update toBeDetached to 'true' along with setting detachOption: 'ForceDetach'.
        /// </summary>
        [JsonPropertyName("detachOption")]
        public string DetachOption { get; set; }

        /// <summary>
        /// Specifies whether data disk should be deleted or detached upon VM deletion.<br><br> Possible values: <br><br> **Delete** If this value is used, the data disk is deleted when VM is deleted.<br><br> **Detach** If this value is used, the data disk is retained after VM is deleted.<br><br> The default value is set to **detach**
        /// </summary>
        [JsonPropertyName("deleteOption")]
        public string DeleteOption { get; set; }
    }
}