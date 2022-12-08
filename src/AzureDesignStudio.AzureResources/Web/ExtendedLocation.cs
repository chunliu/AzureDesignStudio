// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Web
{
    /// <summary>
    /// ExtendedLocation
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ExtendedLocation
    {
        /// <summary>
        /// Name of extended location.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Type of extended location.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}