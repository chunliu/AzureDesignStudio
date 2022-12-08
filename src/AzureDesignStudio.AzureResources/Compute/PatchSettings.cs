// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Compute
{
    /// <summary>
    /// PatchSettings
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class PatchSettings
    {
        /// <summary>
        /// Specifies the mode of VM Guest Patching to IaaS virtual machine or virtual machines associated to virtual machine scale set with OrchestrationMode as Flexible.<br /><br /> Possible values are:<br /><br /> **Manual** - You  control the application of patches to a virtual machine. You do this by applying patches manually inside the VM. In this mode, automatic updates are disabled; the property WindowsConfiguration.enableAutomaticUpdates must be false<br /><br /> **AutomaticByOS** - The virtual machine will automatically be updated by the OS. The property WindowsConfiguration.enableAutomaticUpdates must be true. <br /><br /> **AutomaticByPlatform** - the virtual machine will automatically updated by the platform. The properties provisionVMAgent and WindowsConfiguration.enableAutomaticUpdates must be true
        /// </summary>
        [JsonPropertyName("patchMode")]
        public string PatchMode { get; set; }

        /// <summary>
        /// Enables customers to patch their Azure VMs without requiring a reboot. For enableHotpatching, the 'provisionVMAgent' must be set to true and 'patchMode' must be set to 'AutomaticByPlatform'.
        /// </summary>
        [JsonPropertyName("enableHotpatching")]
        public bool EnableHotpatching { get; set; }

        /// <summary>
        /// Specifies the mode of VM Guest patch assessment for the IaaS virtual machine.<br /><br /> Possible values are:<br /><br /> **ImageDefault** - You control the timing of patch assessments on a virtual machine.<br /><br /> **AutomaticByPlatform** - The platform will trigger periodic patch assessments. The property provisionVMAgent must be true.
        /// </summary>
        [JsonPropertyName("assessmentMode")]
        public string AssessmentMode { get; set; }

        /// <summary>
        /// Specifies additional settings for patch mode AutomaticByPlatform in VM Guest Patching on Windows.
        /// </summary>
        [JsonPropertyName("automaticByPlatformSettings")]
        public WindowsVMGuestPatchAutomaticByPlatformSettings AutomaticByPlatformSettings { get; set; }
    }
}