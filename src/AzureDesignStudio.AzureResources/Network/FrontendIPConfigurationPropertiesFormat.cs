// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// FrontendIPConfigurationPropertiesFormat
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class FrontendIPConfigurationPropertiesFormat
    {
        /// <summary>
        /// An array of references to inbound rules that use this frontend IP.
        /// </summary>
        [JsonPropertyName("inboundNatRules")]
        public IList<SubResource> InboundNatRules { get; set; }

        /// <summary>
        /// An array of references to inbound pools that use this frontend IP.
        /// </summary>
        [JsonPropertyName("inboundNatPools")]
        public IList<SubResource> InboundNatPools { get; set; }

        /// <summary>
        /// An array of references to outbound rules that use this frontend IP.
        /// </summary>
        [JsonPropertyName("outboundRules")]
        public IList<SubResource> OutboundRules { get; set; }

        /// <summary>
        /// An array of references to load balancing rules that use this frontend IP.
        /// </summary>
        [JsonPropertyName("loadBalancingRules")]
        public IList<SubResource> LoadBalancingRules { get; set; }

        /// <summary>
        /// The private IP address of the IP configuration.
        /// </summary>
        [JsonPropertyName("privateIPAddress")]
        public string PrivateIPAddress { get; set; }

        /// <summary>
        /// The Private IP allocation method.
        /// </summary>
        [JsonPropertyName("privateIPAllocationMethod")]
        public string PrivateIPAllocationMethod { get; set; }

        /// <summary>
        /// Whether the specific ipconfiguration is IPv4 or IPv6. Default is taken as IPv4.
        /// </summary>
        [JsonPropertyName("privateIPAddressVersion")]
        public string PrivateIPAddressVersion { get; set; }

        /// <summary>
        /// The reference to the subnet resource.
        /// </summary>
        [JsonPropertyName("subnet")]
        public Subnet Subnet { get; set; }

        /// <summary>
        /// The reference to the Public IP resource.
        /// </summary>
        [JsonPropertyName("publicIPAddress")]
        public PublicIPAddress PublicIPAddress { get; set; }

        /// <summary>
        /// The reference to the Public IP Prefix resource.
        /// </summary>
        [JsonPropertyName("publicIPPrefix")]
        public SubResource PublicIPPrefix { get; set; }

        /// <summary>
        /// The reference to gateway load balancer frontend IP.
        /// </summary>
        [JsonPropertyName("gatewayLoadBalancer")]
        public SubResource GatewayLoadBalancer { get; set; }

        /// <summary>
        /// The provisioning state of the frontend IP configuration resource.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }
    }
}