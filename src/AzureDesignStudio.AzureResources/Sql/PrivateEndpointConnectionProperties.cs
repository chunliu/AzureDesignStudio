// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Sql
{
    /// <summary>
    /// PrivateEndpointConnectionProperties
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class PrivateEndpointConnectionProperties
    {
        /// <summary>
        /// Private endpoint which the connection belongs to.
        /// </summary>
        [JsonPropertyName("privateEndpoint")]
        public PrivateEndpointProperty PrivateEndpoint { get; set; }

        /// <summary>
        /// Group IDs.
        /// </summary>
        [JsonPropertyName("groupIds")]
        public IList<string> GroupIds { get; set; }

        /// <summary>
        /// Connection state of the private endpoint connection.
        /// </summary>
        [JsonPropertyName("privateLinkServiceConnectionState")]
        public PrivateLinkServiceConnectionStateProperty PrivateLinkServiceConnectionState { get; set; }

        /// <summary>
        /// State of the private endpoint connection.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }
    }
}