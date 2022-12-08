// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Compute
{
    /// <summary>
    /// NetworkInterfaceReference
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class NetworkInterfaceReference
    {
        /// <summary>
        /// Describes a network interface reference properties.
        /// </summary>
        [JsonPropertyName("properties")]
        public NetworkInterfaceReferenceProperties Properties { get; set; }

        /// <summary>
        /// Resource Id
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}