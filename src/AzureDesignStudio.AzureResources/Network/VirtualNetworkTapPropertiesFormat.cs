// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// VirtualNetworkTapPropertiesFormat
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class VirtualNetworkTapPropertiesFormat
    {
        /// <summary>
        /// Specifies the list of resource IDs for the network interface IP configuration that needs to be tapped.
        /// </summary>
        [JsonPropertyName("networkInterfaceTapConfigurations")]
        public IList<NetworkInterfaceTapConfiguration> NetworkInterfaceTapConfigurations { get; set; }

        /// <summary>
        /// The resource GUID property of the virtual network tap resource.
        /// </summary>
        [JsonPropertyName("resourceGuid")]
        public string ResourceGuid { get; set; }

        /// <summary>
        /// The provisioning state of the virtual network tap resource.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }

        /// <summary>
        /// The reference to the private IP Address of the collector nic that will receive the tap.
        /// </summary>
        [JsonPropertyName("destinationNetworkInterfaceIPConfiguration")]
        public NetworkInterfaceIPConfiguration DestinationNetworkInterfaceIPConfiguration { get; set; }

        /// <summary>
        /// The reference to the private IP address on the internal Load Balancer that will receive the tap.
        /// </summary>
        [JsonPropertyName("destinationLoadBalancerFrontEndIPConfiguration")]
        public FrontendIPConfiguration DestinationLoadBalancerFrontEndIPConfiguration { get; set; }

        /// <summary>
        /// The VXLAN destination port that will receive the tapped traffic.
        /// </summary>
        [JsonPropertyName("destinationPort")]
        public int DestinationPort { get; set; }
    }
}