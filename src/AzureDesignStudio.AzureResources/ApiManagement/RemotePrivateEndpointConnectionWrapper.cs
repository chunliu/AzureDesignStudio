// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.ApiManagement
{
    /// <summary>
    /// RemotePrivateEndpointConnectionWrapper
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class RemotePrivateEndpointConnectionWrapper
    {
        /// <summary>
        /// Private Endpoint connection resource id
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Private Endpoint Connection Name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Private Endpoint Connection Resource Type
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// Resource properties.
        /// </summary>
        [JsonPropertyName("properties")]
        public PrivateEndpointConnectionWrapperProperties Properties { get; set; }
    }
}