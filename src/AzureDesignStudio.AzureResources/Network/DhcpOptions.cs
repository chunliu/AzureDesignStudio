// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// DhcpOptions
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class DhcpOptions
    {
        /// <summary>
        /// The list of DNS servers IP addresses.
        /// </summary>
        [JsonPropertyName("dnsServers")]
        public IList<string> DnsServers { get; set; }
    }
}