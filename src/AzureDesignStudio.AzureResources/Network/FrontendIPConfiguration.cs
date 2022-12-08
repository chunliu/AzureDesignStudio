// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// FrontendIPConfiguration
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class FrontendIPConfiguration
    {
        /// <summary>
        /// Properties of the load balancer probe.
        /// </summary>
        [JsonPropertyName("properties")]
        public FrontendIPConfigurationPropertiesFormat Properties { get; set; }

        /// <summary>
        /// The name of the resource that is unique within the set of frontend IP configurations used by the load balancer. This name can be used to access the resource.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// A unique read-only string that changes whenever the resource is updated.
        /// </summary>
        [JsonPropertyName("etag")]
        public string Etag { get; set; }

        /// <summary>
        /// Type of the resource.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// A list of availability zones denoting the IP allocated for the resource needs to come from.
        /// </summary>
        [JsonPropertyName("zones")]
        public IList<string> Zones { get; set; }

        /// <summary>
        /// Resource ID.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}