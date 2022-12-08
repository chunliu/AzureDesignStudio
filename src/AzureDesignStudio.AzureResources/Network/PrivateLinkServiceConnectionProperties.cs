// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// PrivateLinkServiceConnectionProperties
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class PrivateLinkServiceConnectionProperties
    {
        /// <summary>
        /// The provisioning state of the private link service connection resource.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }

        /// <summary>
        /// The resource id of private link service.
        /// </summary>
        [JsonPropertyName("privateLinkServiceId")]
        public string PrivateLinkServiceId { get; set; }

        /// <summary>
        /// The ID(s) of the group(s) obtained from the remote resource that this private endpoint should connect to.
        /// </summary>
        [JsonPropertyName("groupIds")]
        public IList<string> GroupIds { get; set; }

        /// <summary>
        /// A message passed to the owner of the remote resource with this connection request. Restricted to 140 chars.
        /// </summary>
        [JsonPropertyName("requestMessage")]
        public string RequestMessage { get; set; }

        /// <summary>
        /// A collection of read-only information about the state of the connection to the remote resource.
        /// </summary>
        [JsonPropertyName("privateLinkServiceConnectionState")]
        public PrivateLinkServiceConnectionState PrivateLinkServiceConnectionState { get; set; }
    }
}