// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Compute
{
    /// <summary>
    /// VirtualMachineAgentInstanceView
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class VirtualMachineAgentInstanceView
    {
        /// <summary>
        /// The VM Agent full version.
        /// </summary>
        [JsonPropertyName("vmAgentVersion")]
        public string VmAgentVersion { get; set; }

        /// <summary>
        /// The virtual machine extension handler instance view.
        /// </summary>
        [JsonPropertyName("extensionHandlers")]
        public IList<VirtualMachineExtensionHandlerInstanceView> ExtensionHandlers { get; set; }

        /// <summary>
        /// The resource status information.
        /// </summary>
        [JsonPropertyName("statuses")]
        public IList<InstanceViewStatus> Statuses { get; set; }
    }
}