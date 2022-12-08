// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Sql
{
    /// <summary>
    /// ServerPrivateEndpointConnection
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ServerPrivateEndpointConnection
    {
        /// <summary>
        /// Resource ID.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Private endpoint connection properties
        /// </summary>
        [JsonPropertyName("properties")]
        public PrivateEndpointConnectionProperties Properties { get; set; }
    }
}