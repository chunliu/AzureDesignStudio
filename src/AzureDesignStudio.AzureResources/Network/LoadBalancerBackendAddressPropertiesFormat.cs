// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// LoadBalancerBackendAddressPropertiesFormat
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class LoadBalancerBackendAddressPropertiesFormat
    {
        /// <summary>
        /// Reference to an existing virtual network.
        /// </summary>
        [JsonPropertyName("virtualNetwork")]
        public SubResource VirtualNetwork { get; set; }

        /// <summary>
        /// Reference to an existing subnet.
        /// </summary>
        [JsonPropertyName("subnet")]
        public SubResource Subnet { get; set; }

        /// <summary>
        /// IP Address belonging to the referenced virtual network.
        /// </summary>
        [JsonPropertyName("ipAddress")]
        public string IpAddress { get; set; }

        /// <summary>
        /// Reference to IP address defined in network interfaces.
        /// </summary>
        [JsonPropertyName("networkInterfaceIPConfiguration")]
        public SubResource NetworkInterfaceIPConfiguration { get; set; }

        /// <summary>
        /// Reference to the frontend ip address configuration defined in regional loadbalancer.
        /// </summary>
        [JsonPropertyName("loadBalancerFrontendIPConfiguration")]
        public SubResource LoadBalancerFrontendIPConfiguration { get; set; }

        /// <summary>
        /// Collection of inbound NAT rule port mappings.
        /// </summary>
        [JsonPropertyName("inboundNatRulesPortMapping")]
        public IList<NatRulePortMapping> InboundNatRulesPortMapping { get; set; }

        /// <summary>
        /// A list of administrative states which once set can override health probe so that Load Balancer will always forward new connections to backend, or deny new connections and reset existing connections.
        /// </summary>
        [JsonPropertyName("adminState")]
        public string AdminState { get; set; }
    }
}