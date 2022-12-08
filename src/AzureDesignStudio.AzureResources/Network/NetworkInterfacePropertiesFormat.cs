// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// NetworkInterfacePropertiesFormat
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class NetworkInterfacePropertiesFormat
    {
        /// <summary>
        /// The reference to a virtual machine.
        /// </summary>
        [JsonPropertyName("virtualMachine")]
        public SubResource VirtualMachine { get; set; }

        /// <summary>
        /// The reference to the NetworkSecurityGroup resource.
        /// </summary>
        [JsonPropertyName("networkSecurityGroup")]
        public NetworkSecurityGroup NetworkSecurityGroup { get; set; }

        /// <summary>
        /// A reference to the private endpoint to which the network interface is linked.
        /// </summary>
        [JsonPropertyName("privateEndpoint")]
        public PrivateEndpoint PrivateEndpoint { get; set; }

        /// <summary>
        /// A list of IPConfigurations of the network interface.
        /// </summary>
        [JsonPropertyName("ipConfigurations")]
        public IList<NetworkInterfaceIPConfiguration> IpConfigurations { get; set; }

        /// <summary>
        /// A list of TapConfigurations of the network interface.
        /// </summary>
        [JsonPropertyName("tapConfigurations")]
        public IList<NetworkInterfaceTapConfiguration> TapConfigurations { get; set; }

        /// <summary>
        /// The DNS settings in network interface.
        /// </summary>
        [JsonPropertyName("dnsSettings")]
        public NetworkInterfaceDnsSettings DnsSettings { get; set; }

        /// <summary>
        /// The MAC address of the network interface.
        /// </summary>
        [JsonPropertyName("macAddress")]
        public string MacAddress { get; set; }

        /// <summary>
        /// Whether this is a primary network interface on a virtual machine.
        /// </summary>
        [JsonPropertyName("primary")]
        public bool Primary { get; set; }

        /// <summary>
        /// Whether the virtual machine this nic is attached to supports encryption.
        /// </summary>
        [JsonPropertyName("vnetEncryptionSupported")]
        public bool VnetEncryptionSupported { get; set; }

        /// <summary>
        /// If the network interface is configured for accelerated networking. Not applicable to VM sizes which require accelerated networking.
        /// </summary>
        [JsonPropertyName("enableAcceleratedNetworking")]
        public bool EnableAcceleratedNetworking { get; set; }

        /// <summary>
        /// Indicates whether to disable tcp state tracking.
        /// </summary>
        [JsonPropertyName("disableTcpStateTracking")]
        public bool DisableTcpStateTracking { get; set; }

        /// <summary>
        /// Indicates whether IP forwarding is enabled on this network interface.
        /// </summary>
        [JsonPropertyName("enableIPForwarding")]
        public bool EnableIPForwarding { get; set; }

        /// <summary>
        /// A list of references to linked BareMetal resources.
        /// </summary>
        [JsonPropertyName("hostedWorkloads")]
        public IList<string> HostedWorkloads { get; set; }

        /// <summary>
        /// A reference to the dscp configuration to which the network interface is linked.
        /// </summary>
        [JsonPropertyName("dscpConfiguration")]
        public SubResource DscpConfiguration { get; set; }

        /// <summary>
        /// The resource GUID property of the network interface resource.
        /// </summary>
        [JsonPropertyName("resourceGuid")]
        public string ResourceGuid { get; set; }

        /// <summary>
        /// The provisioning state of the network interface resource.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }

        /// <summary>
        /// WorkloadType of the NetworkInterface for BareMetal resources
        /// </summary>
        [JsonPropertyName("workloadType")]
        public string WorkloadType { get; set; }

        /// <summary>
        /// Type of Network Interface resource.
        /// </summary>
        [JsonPropertyName("nicType")]
        public string NicType { get; set; }

        /// <summary>
        /// Privatelinkservice of the network interface resource.
        /// </summary>
        [JsonPropertyName("privateLinkService")]
        public PrivateLinkService PrivateLinkService { get; set; }

        /// <summary>
        /// Migration phase of Network Interface resource.
        /// </summary>
        [JsonPropertyName("migrationPhase")]
        public string MigrationPhase { get; set; }

        /// <summary>
        /// Auxiliary mode of Network Interface resource.
        /// </summary>
        [JsonPropertyName("auxiliaryMode")]
        public string AuxiliaryMode { get; set; }
    }
}