// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// ApplicationGatewayPathRule
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ApplicationGatewayPathRule
    {
        /// <summary>
        /// Properties of the application gateway path rule.
        /// </summary>
        [JsonPropertyName("properties")]
        public ApplicationGatewayPathRulePropertiesFormat Properties { get; set; }

        /// <summary>
        /// Name of the path rule that is unique within an Application Gateway.
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
        /// Resource ID.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}