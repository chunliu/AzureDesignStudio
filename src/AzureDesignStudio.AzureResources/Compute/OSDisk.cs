// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Compute
{
    /// <summary>
    /// OSDisk
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class OSDisk
    {
        /// <summary>
        /// This property allows you to specify the type of the OS that is included in the disk if creating a VM from user-image or a specialized VHD. <br><br> Possible values are: <br><br> **Windows** <br><br> **Linux**
        /// </summary>
        [JsonPropertyName("osType")]
        public string OsType { get; set; }

        /// <summary>
        /// Specifies the encryption settings for the OS Disk. <br><br> Minimum api-version: 2015-06-15
        /// </summary>
        [JsonPropertyName("encryptionSettings")]
        public DiskEncryptionSettings EncryptionSettings { get; set; }

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
        /// Specifies the caching requirements. <br><br> Possible values are: <br><br> **None** <br><br> **ReadOnly** <br><br> **ReadWrite** <br><br> Default: **None** for Standard storage. **ReadOnly** for Premium storage.
        /// </summary>
        [JsonPropertyName("caching")]
        public string Caching { get; set; }

        /// <summary>
        /// Specifies whether writeAccelerator should be enabled or disabled on the disk.
        /// </summary>
        [JsonPropertyName("writeAcceleratorEnabled")]
        public bool WriteAcceleratorEnabled { get; set; }

        /// <summary>
        /// Specifies the ephemeral Disk Settings for the operating system disk used by the virtual machine.
        /// </summary>
        [JsonPropertyName("diffDiskSettings")]
        public DiffDiskSettings DiffDiskSettings { get; set; }

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
        /// Specifies whether OS Disk should be deleted or detached upon VM deletion. <br><br> Possible values: <br><br> **Delete** If this value is used, the OS disk is deleted when VM is deleted.<br><br> **Detach** If this value is used, the os disk is retained after VM is deleted. <br><br> The default value is set to **detach**. For an ephemeral OS Disk, the default value is set to **Delete**. User cannot change the delete option for ephemeral OS Disk.
        /// </summary>
        [JsonPropertyName("deleteOption")]
        public string DeleteOption { get; set; }
    }
}