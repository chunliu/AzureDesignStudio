// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Web
{
    /// <summary>
    /// PushSettings
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class PushSettings
    {
        /// <summary>
        /// PushSettings resource specific properties
        /// </summary>
        [JsonPropertyName("properties")]
        public PushSettingsProperties Properties { get; set; }

        /// <summary>
        /// Resource Id.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Resource Name.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Kind of resource.
        /// </summary>
        [JsonPropertyName("kind")]
        public string Kind { get; set; }

        /// <summary>
        /// Resource type.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}