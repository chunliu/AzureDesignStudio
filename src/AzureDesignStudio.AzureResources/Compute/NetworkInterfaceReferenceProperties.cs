// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Compute
{
    /// <summary>
    /// NetworkInterfaceReferenceProperties
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class NetworkInterfaceReferenceProperties
    {
        /// <summary>
        /// Specifies the primary network interface in case the virtual machine has more than 1 network interface.
        /// </summary>
        [JsonPropertyName("primary")]
        public bool Primary { get; set; }

        /// <summary>
        /// Specify what happens to the network interface when the VM is deleted
        /// </summary>
        [JsonPropertyName("deleteOption")]
        public string DeleteOption { get; set; }
    }
}