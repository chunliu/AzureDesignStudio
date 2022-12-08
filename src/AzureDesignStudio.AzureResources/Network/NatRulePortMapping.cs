// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// NatRulePortMapping
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class NatRulePortMapping
    {
        /// <summary>
        /// Name of inbound NAT rule.
        /// </summary>
        [JsonPropertyName("inboundNatRuleName")]
        public string InboundNatRuleName { get; set; }

        /// <summary>
        /// Frontend port.
        /// </summary>
        [JsonPropertyName("frontendPort")]
        public int FrontendPort { get; set; }

        /// <summary>
        /// Backend port.
        /// </summary>
        [JsonPropertyName("backendPort")]
        public int BackendPort { get; set; }
    }
}