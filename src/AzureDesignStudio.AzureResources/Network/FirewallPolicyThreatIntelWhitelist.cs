// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// FirewallPolicyThreatIntelWhitelist
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class FirewallPolicyThreatIntelWhitelist
    {
        /// <summary>
        /// List of IP addresses for the ThreatIntel Whitelist.
        /// </summary>
        [JsonPropertyName("ipAddresses")]
        public IList<string> IpAddresses { get; set; }

        /// <summary>
        /// List of FQDNs for the ThreatIntel Whitelist.
        /// </summary>
        [JsonPropertyName("fqdns")]
        public IList<string> Fqdns { get; set; }
    }
}