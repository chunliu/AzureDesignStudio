// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// VirtualNetworkPeeringPropertiesFormat
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class VirtualNetworkPeeringPropertiesFormat
    {
        /// <summary>
        /// Whether the VMs in the local virtual network space would be able to access the VMs in remote virtual network space.
        /// </summary>
        [JsonPropertyName("allowVirtualNetworkAccess")]
        public bool AllowVirtualNetworkAccess { get; set; }

        /// <summary>
        /// Whether the forwarded traffic from the VMs in the local virtual network will be allowed/disallowed in remote virtual network.
        /// </summary>
        [JsonPropertyName("allowForwardedTraffic")]
        public bool AllowForwardedTraffic { get; set; }

        /// <summary>
        /// If gateway links can be used in remote virtual networking to link to this virtual network.
        /// </summary>
        [JsonPropertyName("allowGatewayTransit")]
        public bool AllowGatewayTransit { get; set; }

        /// <summary>
        /// If remote gateways can be used on this virtual network. If the flag is set to true, and allowGatewayTransit on remote peering is also true, virtual network will use gateways of remote virtual network for transit. Only one peering can have this flag set to true. This flag cannot be set if virtual network already has a gateway.
        /// </summary>
        [JsonPropertyName("useRemoteGateways")]
        public bool UseRemoteGateways { get; set; }

        /// <summary>
        /// The reference to the remote virtual network. The remote virtual network can be in the same or different region (preview). See here to register for the preview and learn more (https://docs.microsoft.com/en-us/azure/virtual-network/virtual-network-create-peering).
        /// </summary>
        [JsonPropertyName("remoteVirtualNetwork")]
        public SubResource RemoteVirtualNetwork { get; set; }

        /// <summary>
        /// The reference to the address space peered with the remote virtual network.
        /// </summary>
        [JsonPropertyName("remoteAddressSpace")]
        public AddressSpace RemoteAddressSpace { get; set; }

        /// <summary>
        /// The reference to the current address space of the remote virtual network.
        /// </summary>
        [JsonPropertyName("remoteVirtualNetworkAddressSpace")]
        public AddressSpace RemoteVirtualNetworkAddressSpace { get; set; }

        /// <summary>
        /// The reference to the remote virtual network's Bgp Communities.
        /// </summary>
        [JsonPropertyName("remoteBgpCommunities")]
        public VirtualNetworkBgpCommunities RemoteBgpCommunities { get; set; }

        /// <summary>
        /// The reference to the remote virtual network's encryption
        /// </summary>
        [JsonPropertyName("remoteVirtualNetworkEncryption")]
        public VirtualNetworkEncryption RemoteVirtualNetworkEncryption { get; set; }

        /// <summary>
        /// The status of the virtual network peering.
        /// </summary>
        [JsonPropertyName("peeringState")]
        public string PeeringState { get; set; }

        /// <summary>
        /// The peering sync status of the virtual network peering.
        /// </summary>
        [JsonPropertyName("peeringSyncLevel")]
        public string PeeringSyncLevel { get; set; }

        /// <summary>
        /// The provisioning state of the virtual network peering resource.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }

        /// <summary>
        /// If we need to verify the provisioning state of the remote gateway.
        /// </summary>
        [JsonPropertyName("doNotVerifyRemoteGateways")]
        public bool DoNotVerifyRemoteGateways { get; set; }

        /// <summary>
        /// The resourceGuid property of the Virtual Network peering resource.
        /// </summary>
        [JsonPropertyName("resourceGuid")]
        public string ResourceGuid { get; set; }
    }
}