// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Compute
{
    /// <summary>
    /// VirtualMachineExtensionInstanceView
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class VirtualMachineExtensionInstanceView
    {
        /// <summary>
        /// The virtual machine extension name.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

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
        /// The resource status information.
        /// </summary>
        [JsonPropertyName("substatuses")]
        public IList<InstanceViewStatus> Substatuses { get; set; }

        /// <summary>
        /// The resource status information.
        /// </summary>
        [JsonPropertyName("statuses")]
        public IList<InstanceViewStatus> Statuses { get; set; }
    }
}