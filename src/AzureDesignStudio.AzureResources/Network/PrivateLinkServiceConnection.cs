// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// PrivateLinkServiceConnection
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class PrivateLinkServiceConnection
    {
        /// <summary>
        /// Properties of the private link service connection.
        /// </summary>
        [JsonPropertyName("properties")]
        public PrivateLinkServiceConnectionProperties Properties { get; set; }

        /// <summary>
        /// The name of the resource that is unique within a resource group. This name can be used to access the resource.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The resource type.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// A unique read-only string that changes whenever the resource is updated.
        /// </summary>
        [JsonPropertyName("etag")]
        public string Etag { get; set; }

        /// <summary>
        /// Resource ID.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}