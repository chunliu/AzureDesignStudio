// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// VirtualNetworkPropertiesFormat
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class VirtualNetworkPropertiesFormat
    {
        /// <summary>
        /// The AddressSpace that contains an array of IP address ranges that can be used by subnets.
        /// </summary>
        [JsonPropertyName("addressSpace")]
        public AddressSpace AddressSpace { get; set; }

        /// <summary>
        /// The dhcpOptions that contains an array of DNS servers available to VMs deployed in the virtual network.
        /// </summary>
        [JsonPropertyName("dhcpOptions")]
        public DhcpOptions DhcpOptions { get; set; }

        /// <summary>
        /// The FlowTimeout value (in minutes) for the Virtual Network
        /// </summary>
        [JsonPropertyName("flowTimeoutInMinutes")]
        public int FlowTimeoutInMinutes { get; set; }

        /// <summary>
        /// A list of subnets in a Virtual Network.
        /// </summary>
        [JsonPropertyName("subnets")]
        public IList<Subnet> Subnets { get; set; }

        /// <summary>
        /// A list of peerings in a Virtual Network.
        /// </summary>
        [JsonPropertyName("virtualNetworkPeerings")]
        public IList<VirtualNetworkPeering> VirtualNetworkPeerings { get; set; }

        /// <summary>
        /// The resourceGuid property of the Virtual Network resource.
        /// </summary>
        [JsonPropertyName("resourceGuid")]
        public string ResourceGuid { get; set; }

        /// <summary>
        /// The provisioning state of the virtual network resource.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Indicates if DDoS protection is enabled for all the protected resources in the virtual network. It requires a DDoS protection plan associated with the resource.
        /// </summary>
        [JsonPropertyName("enableDdosProtection")]
        public bool EnableDdosProtection { get; set; }

        /// <summary>
        /// Indicates if VM protection is enabled for all the subnets in the virtual network.
        /// </summary>
        [JsonPropertyName("enableVmProtection")]
        public bool EnableVmProtection { get; set; }

        /// <summary>
        /// The DDoS protection plan associated with the virtual network.
        /// </summary>
        [JsonPropertyName("ddosProtectionPlan")]
        public SubResource DdosProtectionPlan { get; set; }

        /// <summary>
        /// Bgp Communities sent over ExpressRoute with each route corresponding to a prefix in this VNET.
        /// </summary>
        [JsonPropertyName("bgpCommunities")]
        public VirtualNetworkBgpCommunities BgpCommunities { get; set; }

        /// <summary>
        /// Indicates if encryption is enabled on virtual network and if VM without encryption is allowed in encrypted VNet.
        /// </summary>
        [JsonPropertyName("encryption")]
        public VirtualNetworkEncryption Encryption { get; set; }

        /// <summary>
        /// Array of IpAllocation which reference this VNET.
        /// </summary>
        [JsonPropertyName("ipAllocations")]
        public IList<SubResource> IpAllocations { get; set; }
    }
}