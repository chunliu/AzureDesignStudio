// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// NetworkInterfaceIPConfigurationPrivateLinkConnectionProperties
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class NetworkInterfaceIPConfigurationPrivateLinkConnectionProperties
    {
        /// <summary>
        /// The group ID for current private link connection.
        /// </summary>
        [JsonPropertyName("groupId")]
        public string GroupId { get; set; }

        /// <summary>
        /// The required member name for current private link connection.
        /// </summary>
        [JsonPropertyName("requiredMemberName")]
        public string RequiredMemberName { get; set; }

        /// <summary>
        /// List of FQDNs for current private link connection.
        /// </summary>
        [JsonPropertyName("fqdns")]
        public IList<string> Fqdns { get; set; }
    }
}