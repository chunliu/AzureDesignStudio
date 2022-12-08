// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// HubPublicIPAddresses
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class HubPublicIPAddresses
    {
        /// <summary>
        /// The list of Public IP addresses associated with azure firewall or IP addresses to be retained.
        /// </summary>
        [JsonPropertyName("addresses")]
        public IList<AzureFirewallPublicIPAddress> Addresses { get; set; }

        /// <summary>
        /// The number of Public IP addresses associated with azure firewall.
        /// </summary>
        [JsonPropertyName("count")]
        public int Count { get; set; }
    }
}