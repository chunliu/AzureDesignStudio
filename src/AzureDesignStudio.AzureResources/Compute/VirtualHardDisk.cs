// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Compute
{
    /// <summary>
    /// VirtualHardDisk
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class VirtualHardDisk
    {
        /// <summary>
        /// Specifies the virtual hard disk's uri.
        /// </summary>
        [JsonPropertyName("uri")]
        public string Uri { get; set; }
    }
}