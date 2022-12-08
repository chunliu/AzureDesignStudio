// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// NetworkInterfaceIPConfigurationPropertiesFormat
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class NetworkInterfaceIPConfigurationPropertiesFormat
    {
        /// <summary>
        /// The reference to gateway load balancer frontend IP.
        /// </summary>
        [JsonPropertyName("gatewayLoadBalancer")]
        public SubResource GatewayLoadBalancer { get; set; }

        /// <summary>
        /// The reference to Virtual Network Taps.
        /// </summary>
        [JsonPropertyName("virtualNetworkTaps")]
        public IList<VirtualNetworkTap> VirtualNetworkTaps { get; set; }

        /// <summary>
        /// The reference to ApplicationGatewayBackendAddressPool resource.
        /// </summary>
        [JsonPropertyName("applicationGatewayBackendAddressPools")]
        public IList<ApplicationGatewayBackendAddressPool> ApplicationGatewayBackendAddressPools { get; set; }

        /// <summary>
        /// The reference to LoadBalancerBackendAddressPool resource.
        /// </summary>
        [JsonPropertyName("loadBalancerBackendAddressPools")]
        public IList<BackendAddressPool> LoadBalancerBackendAddressPools { get; set; }

        /// <summary>
        /// A list of references of LoadBalancerInboundNatRules.
        /// </summary>
        [JsonPropertyName("loadBalancerInboundNatRules")]
        public IList<InboundNatRule> LoadBalancerInboundNatRules { get; set; }

        /// <summary>
        /// Private IP address of the IP configuration.
        /// </summary>
        [JsonPropertyName("privateIPAddress")]
        public string PrivateIPAddress { get; set; }

        /// <summary>
        /// The private IP address allocation method.
        /// </summary>
        [JsonPropertyName("privateIPAllocationMethod")]
        public string PrivateIPAllocationMethod { get; set; }

        /// <summary>
        /// Whether the specific IP configuration is IPv4 or IPv6. Default is IPv4.
        /// </summary>
        [JsonPropertyName("privateIPAddressVersion")]
        public string PrivateIPAddressVersion { get; set; }

        /// <summary>
        /// Subnet bound to the IP configuration.
        /// </summary>
        [JsonPropertyName("subnet")]
        public Subnet Subnet { get; set; }

        /// <summary>
        /// Whether this is a primary customer address on the network interface.
        /// </summary>
        [JsonPropertyName("primary")]
        public bool Primary { get; set; }

        /// <summary>
        /// Public IP address bound to the IP configuration.
        /// </summary>
        [JsonPropertyName("publicIPAddress")]
        public PublicIPAddress PublicIPAddress { get; set; }

        /// <summary>
        /// Application security groups in which the IP configuration is included.
        /// </summary>
        [JsonPropertyName("applicationSecurityGroups")]
        public IList<ApplicationSecurityGroup> ApplicationSecurityGroups { get; set; }

        /// <summary>
        /// The provisioning state of the network interface IP configuration.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }

        /// <summary>
        /// PrivateLinkConnection properties for the network interface.
        /// </summary>
        [JsonPropertyName("privateLinkConnectionProperties")]
        public NetworkInterfaceIPConfigurationPrivateLinkConnectionProperties PrivateLinkConnectionProperties { get; set; }
    }
}