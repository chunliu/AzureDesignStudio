// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// PrivateEndpointConnectionProperties
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class PrivateEndpointConnectionProperties
    {
        /// <summary>
        /// The resource of private end point.
        /// </summary>
        [JsonPropertyName("privateEndpoint")]
        public PrivateEndpoint PrivateEndpoint { get; set; }

        /// <summary>
        /// A collection of information about the state of the connection between service consumer and provider.
        /// </summary>
        [JsonPropertyName("privateLinkServiceConnectionState")]
        public PrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get; set; }

        /// <summary>
        /// The provisioning state of the private endpoint connection resource.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }

        /// <summary>
        /// The consumer link id.
        /// </summary>
        [JsonPropertyName("linkIdentifier")]
        public string LinkIdentifier { get; set; }
    }
}