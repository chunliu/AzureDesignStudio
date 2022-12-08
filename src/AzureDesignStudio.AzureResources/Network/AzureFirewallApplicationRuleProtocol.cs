// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// AzureFirewallApplicationRuleProtocol
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class AzureFirewallApplicationRuleProtocol
    {
        /// <summary>
        /// Protocol type.
        /// </summary>
        [JsonPropertyName("protocolType")]
        public string ProtocolType { get; set; }

        /// <summary>
        /// Port number for the protocol, cannot be greater than 64000. This field is optional.
        /// </summary>
        [JsonPropertyName("port")]
        public int Port { get; set; }
    }
}