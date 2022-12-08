// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// PrivateEndpointIPConfigurationProperties
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class PrivateEndpointIPConfigurationProperties
    {
        /// <summary>
        /// The ID of a group obtained from the remote resource that this private endpoint should connect to.
        /// </summary>
        [JsonPropertyName("groupId")]
        public string GroupId { get; set; }

        /// <summary>
        /// The member name of a group obtained from the remote resource that this private endpoint should connect to.
        /// </summary>
        [JsonPropertyName("memberName")]
        public string MemberName { get; set; }

        /// <summary>
        /// A private ip address obtained from the private endpoint's subnet.
        /// </summary>
        [JsonPropertyName("privateIPAddress")]
        public string PrivateIPAddress { get; set; }
    }
}