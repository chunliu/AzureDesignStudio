// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// PrivateLinkServiceConnectionState
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class PrivateLinkServiceConnectionState
    {
        /// <summary>
        /// Indicates whether the connection has been Approved/Rejected/Removed by the owner of the service.
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        /// The reason for approval/rejection of the connection.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// A message indicating if changes on the service provider require any updates on the consumer.
        /// </summary>
        [JsonPropertyName("actionsRequired")]
        public string ActionsRequired { get; set; }
    }
}