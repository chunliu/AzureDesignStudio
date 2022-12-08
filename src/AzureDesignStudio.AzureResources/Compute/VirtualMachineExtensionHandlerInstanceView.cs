// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Compute
{
    /// <summary>
    /// VirtualMachineExtensionHandlerInstanceView
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class VirtualMachineExtensionHandlerInstanceView
    {
        /// <summary>
        /// Specifies the type of the extension; an example is "CustomScriptExtension".
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// Specifies the version of the script handler.
        /// </summary>
        [JsonPropertyName("typeHandlerVersion")]
        public string TypeHandlerVersion { get; set; }

        /// <summary>
        /// The extension handler status.
        /// </summary>
        [JsonPropertyName("status")]
        public InstanceViewStatus Status { get; set; }
    }
}