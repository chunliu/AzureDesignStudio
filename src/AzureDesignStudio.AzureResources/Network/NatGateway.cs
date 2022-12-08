// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// NatGateway
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class NatGateway
    {
        /// <summary>
        /// The nat gateway SKU.
        /// </summary>
        [JsonPropertyName("sku")]
        public NatGatewaySku Sku { get; set; }

        /// <summary>
        /// Nat Gateway properties.
        /// </summary>
        [JsonPropertyName("properties")]
        public NatGatewayPropertiesFormat Properties { get; set; }

        /// <summary>
        /// A list of availability zones denoting the zone in which Nat Gateway should be deployed.
        /// </summary>
        [JsonPropertyName("zones")]
        public IList<string> Zones { get; set; }

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

        /// <summary>
        /// Resource name.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Resource type.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// Resource location.
        /// </summary>
        [JsonPropertyName("location")]
        public string Location { get; set; }

        /// <summary>
        /// Resource tags.
        /// </summary>
        [JsonPropertyName("tags")]
        public object Tags { get; set; }
    }
}