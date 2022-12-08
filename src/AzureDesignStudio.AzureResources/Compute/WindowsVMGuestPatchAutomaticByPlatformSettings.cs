// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Compute
{
    /// <summary>
    /// WindowsVMGuestPatchAutomaticByPlatformSettings
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class WindowsVMGuestPatchAutomaticByPlatformSettings
    {
        /// <summary>
        /// Specifies the reboot setting for all AutomaticByPlatform patch installation operations.
        /// </summary>
        [JsonPropertyName("rebootSetting")]
        public string RebootSetting { get; set; }
    }
}