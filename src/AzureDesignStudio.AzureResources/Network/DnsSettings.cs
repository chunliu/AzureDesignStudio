// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// DnsSettings
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class DnsSettings
    {
        /// <summary>
        /// List of Custom DNS Servers.
        /// </summary>
        [JsonPropertyName("servers")]
        public IList<string> Servers { get; set; }

        /// <summary>
        /// Enable DNS Proxy on Firewalls attached to the Firewall Policy.
        /// </summary>
        [JsonPropertyName("enableProxy")]
        public bool EnableProxy { get; set; }

        /// <summary>
        /// FQDNs in Network Rules are supported when set to true.
        /// </summary>
        [JsonPropertyName("requireProxyForNetworkRules")]
        public bool RequireProxyForNetworkRules { get; set; }
    }
}