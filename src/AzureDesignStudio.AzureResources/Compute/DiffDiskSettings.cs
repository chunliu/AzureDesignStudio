// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Compute
{
    /// <summary>
    /// DiffDiskSettings
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class DiffDiskSettings
    {
        /// <summary>
        /// Specifies the ephemeral disk settings for operating system disk.
        /// </summary>
        [JsonPropertyName("option")]
        public string Option { get; set; }

        /// <summary>
        /// Specifies the ephemeral disk placement for operating system disk.<br><br> Possible values are: <br><br> **CacheDisk** <br><br> **ResourceDisk** <br><br> Default: **CacheDisk** if one is configured for the VM size otherwise **ResourceDisk** is used.<br><br> Refer to VM size documentation for Windows VM at https://docs.microsoft.com/azure/virtual-machines/windows/sizes and Linux VM at https://docs.microsoft.com/azure/virtual-machines/linux/sizes to check which VM sizes exposes a cache disk.
        /// </summary>
        [JsonPropertyName("placement")]
        public string Placement { get; set; }
    }
}