// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Compute
{
    /// <summary>
    /// VirtualMachineNetworkInterfaceConfigurationProperties
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class VirtualMachineNetworkInterfaceConfigurationProperties
    {
        /// <summary>
        /// Specifies the primary network interface in case the virtual machine has more than 1 network interface.
        /// </summary>
        [JsonPropertyName("primary")]
        public bool Primary { get; set; }

        /// <summary>
        /// Specify what happens to the network interface when the VM is deleted
        /// </summary>
        [JsonPropertyName("deleteOption")]
        public string DeleteOption { get; set; }

        /// <summary>
        /// Specifies whether the network interface is accelerated networking-enabled.
        /// </summary>
        [JsonPropertyName("enableAcceleratedNetworking")]
        public bool EnableAcceleratedNetworking { get; set; }

        /// <summary>
        /// Specifies whether the network interface is disabled for tcp state tracking.
        /// </summary>
        [JsonPropertyName("disableTcpStateTracking")]
        public bool DisableTcpStateTracking { get; set; }

        /// <summary>
        /// Specifies whether the network interface is FPGA networking-enabled.
        /// </summary>
        [JsonPropertyName("enableFpga")]
        public bool EnableFpga { get; set; }

        /// <summary>
        /// Whether IP forwarding enabled on this NIC.
        /// </summary>
        [JsonPropertyName("enableIPForwarding")]
        public bool EnableIPForwarding { get; set; }

        /// <summary>
        /// The network security group.
        /// </summary>
        [JsonPropertyName("networkSecurityGroup")]
        public SubResource NetworkSecurityGroup { get; set; }

        /// <summary>
        /// The dns settings to be applied on the network interfaces.
        /// </summary>
        [JsonPropertyName("dnsSettings")]
        public VirtualMachineNetworkInterfaceDnsSettingsConfiguration DnsSettings { get; set; }

        /// <summary>
        /// Specifies the IP configurations of the network interface.
        /// </summary>
        [Required]
        [JsonPropertyName("ipConfigurations")]
        public IList<VirtualMachineNetworkInterfaceIPConfiguration> IpConfigurations { get; set; }
        [JsonPropertyName("dscpConfiguration")]
        public SubResource DscpConfiguration { get; set; }
    }
}