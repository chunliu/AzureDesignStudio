// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// BackendAddressPoolPropertiesFormat
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class BackendAddressPoolPropertiesFormat
    {
        /// <summary>
        /// The location of the backend address pool.
        /// </summary>
        [JsonPropertyName("location")]
        public string Location { get; set; }

        /// <summary>
        /// An array of gateway load balancer tunnel interfaces.
        /// </summary>
        [JsonPropertyName("tunnelInterfaces")]
        public IList<GatewayLoadBalancerTunnelInterface> TunnelInterfaces { get; set; }

        /// <summary>
        /// An array of backend addresses.
        /// </summary>
        [JsonPropertyName("loadBalancerBackendAddresses")]
        public IList<LoadBalancerBackendAddress> LoadBalancerBackendAddresses { get; set; }

        /// <summary>
        /// An array of references to IP addresses defined in network interfaces.
        /// </summary>
        [JsonPropertyName("backendIPConfigurations")]
        public IList<NetworkInterfaceIPConfiguration> BackendIPConfigurations { get; set; }

        /// <summary>
        /// An array of references to load balancing rules that use this backend address pool.
        /// </summary>
        [JsonPropertyName("loadBalancingRules")]
        public IList<SubResource> LoadBalancingRules { get; set; }

        /// <summary>
        /// A reference to an outbound rule that uses this backend address pool.
        /// </summary>
        [JsonPropertyName("outboundRule")]
        public SubResource OutboundRule { get; set; }

        /// <summary>
        /// An array of references to outbound rules that use this backend address pool.
        /// </summary>
        [JsonPropertyName("outboundRules")]
        public IList<SubResource> OutboundRules { get; set; }

        /// <summary>
        /// An array of references to inbound NAT rules that use this backend address pool.
        /// </summary>
        [JsonPropertyName("inboundNatRules")]
        public IList<SubResource> InboundNatRules { get; set; }

        /// <summary>
        /// The provisioning state of the backend address pool resource.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Amount of seconds Load Balancer waits for before sending RESET to client and backend address.
        /// </summary>
        [JsonPropertyName("drainPeriodInSeconds")]
        public int DrainPeriodInSeconds { get; set; }

        /// <summary>
        /// A reference to a virtual network.
        /// </summary>
        [JsonPropertyName("virtualNetwork")]
        public SubResource VirtualNetwork { get; set; }
    }
}