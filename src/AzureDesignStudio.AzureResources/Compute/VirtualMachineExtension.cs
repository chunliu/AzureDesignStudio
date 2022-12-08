// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Compute
{
    /// <summary>
    /// VirtualMachineExtension
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class VirtualMachineExtension
    {
        /// <summary>
        /// Describes the properties of a Virtual Machine Extension.
        /// </summary>
        [JsonPropertyName("properties")]
        public VirtualMachineExtensionProperties Properties { get; set; }

        /// <summary>
        /// Resource location
        /// </summary>
        [JsonPropertyName("location")]
        public string Location { get; set; }

        /// <summary>
        /// Resource Id
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Resource name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Resource type
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// Resource tags
        /// </summary>
        [JsonPropertyName("tags")]
        public ResourceWithOptionalLocationTags Tags { get; set; }
    }
}