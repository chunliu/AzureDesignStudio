// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Compute
{
    /// <summary>
    /// AdditionalUnattendContent
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class AdditionalUnattendContent
    {
        /// <summary>
        /// The pass name. Currently, the only allowable value is OobeSystem.
        /// </summary>
        [JsonPropertyName("passName")]
        public string PassName { get; set; }

        /// <summary>
        /// The component name. Currently, the only allowable value is Microsoft-Windows-Shell-Setup.
        /// </summary>
        [JsonPropertyName("componentName")]
        public string ComponentName { get; set; }

        /// <summary>
        /// Specifies the name of the setting to which the content applies. Possible values are: FirstLogonCommands and AutoLogon.
        /// </summary>
        [JsonPropertyName("settingName")]
        public string SettingName { get; set; }

        /// <summary>
        /// Specifies the XML formatted content that is added to the unattend.xml file for the specified path and component. The XML must be less than 4KB and must include the root element for the setting or feature that is being inserted.
        /// </summary>
        [JsonPropertyName("content")]
        public string Content { get; set; }
    }
}