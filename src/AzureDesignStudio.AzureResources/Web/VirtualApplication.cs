// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Web
{
    /// <summary>
    /// VirtualApplication
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class VirtualApplication
    {
        /// <summary>
        /// Virtual path.
        /// </summary>
        [JsonPropertyName("virtualPath")]
        public string VirtualPath { get; set; }

        /// <summary>
        /// Physical path.
        /// </summary>
        [JsonPropertyName("physicalPath")]
        public string PhysicalPath { get; set; }

        /// <summary>
        /// <code>true</code> if preloading is enabled; otherwise, <code>false</code>.
        /// </summary>
        [JsonPropertyName("preloadEnabled")]
        public bool PreloadEnabled { get; set; }

        /// <summary>
        /// Virtual directories for virtual application.
        /// </summary>
        [JsonPropertyName("virtualDirectories")]
        public IList<VirtualDirectory> VirtualDirectories { get; set; }
    }
}