// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// GatewayLoadBalancerTunnelInterface
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class GatewayLoadBalancerTunnelInterface
    {
        /// <summary>
        /// Port of gateway load balancer tunnel interface.
        /// </summary>
        [JsonPropertyName("port")]
        public int Port { get; set; }

        /// <summary>
        /// Identifier of gateway load balancer tunnel interface.
        /// </summary>
        [JsonPropertyName("identifier")]
        public int Identifier { get; set; }

        /// <summary>
        /// Protocol of gateway load balancer tunnel interface.
        /// </summary>
        [JsonPropertyName("protocol")]
        public string Protocol { get; set; }

        /// <summary>
        /// Traffic type of gateway load balancer tunnel interface.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}