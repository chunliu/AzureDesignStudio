// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Web
{
    /// <summary>
    /// VirtualDirectory
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class VirtualDirectory
    {
        /// <summary>
        /// Path to virtual application.
        /// </summary>
        [JsonPropertyName("virtualPath")]
        public string VirtualPath { get; set; }

        /// <summary>
        /// Physical path.
        /// </summary>
        [JsonPropertyName("physicalPath")]
        public string PhysicalPath { get; set; }
    }
}