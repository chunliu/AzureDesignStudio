// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// PrivateLinkServiceIpConfiguration
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class PrivateLinkServiceIpConfiguration
    {
        /// <summary>
        /// Properties of the private link service ip configuration.
        /// </summary>
        [JsonPropertyName("properties")]
        public PrivateLinkServiceIpConfigurationProperties Properties { get; set; }

        /// <summary>
        /// The name of private link service ip configuration.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// A unique read-only string that changes whenever the resource is updated.
        /// </summary>
        [JsonPropertyName("etag")]
        public string Etag { get; set; }

        /// <summary>
        /// The resource type.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// Resource ID.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}