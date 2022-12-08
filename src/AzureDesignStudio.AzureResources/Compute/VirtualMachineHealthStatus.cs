// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Compute
{
    /// <summary>
    /// VirtualMachineHealthStatus
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class VirtualMachineHealthStatus
    {
        /// <summary>
        /// The health status information for the VM.
        /// </summary>
        [JsonPropertyName("status")]
        public InstanceViewStatus Status { get; set; }
    }
}