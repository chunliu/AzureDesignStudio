// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Compute
{
    /// <summary>
    /// LinuxPatchSettings
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class LinuxPatchSettings
    {
        /// <summary>
        /// Specifies the mode of VM Guest Patching to IaaS virtual machine or virtual machines associated to virtual machine scale set with OrchestrationMode as Flexible.<br /><br /> Possible values are:<br /><br /> **ImageDefault** - The virtual machine's default patching configuration is used. <br /><br /> **AutomaticByPlatform** - The virtual machine will be automatically updated by the platform. The property provisionVMAgent must be true
        /// </summary>
        [JsonPropertyName("patchMode")]
        public string PatchMode { get; set; }

        /// <summary>
        /// Specifies the mode of VM Guest Patch Assessment for the IaaS virtual machine.<br /><br /> Possible values are:<br /><br /> **ImageDefault** - You control the timing of patch assessments on a virtual machine. <br /><br /> **AutomaticByPlatform** - The platform will trigger periodic patch assessments. The property provisionVMAgent must be true.
        /// </summary>
        [JsonPropertyName("assessmentMode")]
        public string AssessmentMode { get; set; }

        /// <summary>
        /// Specifies additional settings for patch mode AutomaticByPlatform in VM Guest Patching on Linux.
        /// </summary>
        [JsonPropertyName("automaticByPlatformSettings")]
        public LinuxVMGuestPatchAutomaticByPlatformSettings AutomaticByPlatformSettings { get; set; }
    }
}