// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// PrivateEndpointProperties
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class PrivateEndpointProperties
    {
        /// <summary>
        /// The ID of the subnet from which the private IP will be allocated.
        /// </summary>
        [JsonPropertyName("subnet")]
        public Subnet Subnet { get; set; }

        /// <summary>
        /// An array of references to the network interfaces created for this private endpoint.
        /// </summary>
        [JsonPropertyName("networkInterfaces")]
        public IList<NetworkInterface> NetworkInterfaces { get; set; }

        /// <summary>
        /// The provisioning state of the private endpoint resource.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }

        /// <summary>
        /// A grouping of information about the connection to the remote resource.
        /// </summary>
        [JsonPropertyName("privateLinkServiceConnections")]
        public IList<PrivateLinkServiceConnection> PrivateLinkServiceConnections { get; set; }

        /// <summary>
        /// A grouping of information about the connection to the remote resource. Used when the network admin does not have access to approve connections to the remote resource.
        /// </summary>
        [JsonPropertyName("manualPrivateLinkServiceConnections")]
        public IList<PrivateLinkServiceConnection> ManualPrivateLinkServiceConnections { get; set; }

        /// <summary>
        /// An array of custom dns configurations.
        /// </summary>
        [JsonPropertyName("customDnsConfigs")]
        public IList<CustomDnsConfigPropertiesFormat> CustomDnsConfigs { get; set; }

        /// <summary>
        /// Application security groups in which the private endpoint IP configuration is included.
        /// </summary>
        [JsonPropertyName("applicationSecurityGroups")]
        public IList<ApplicationSecurityGroup> ApplicationSecurityGroups { get; set; }

        /// <summary>
        /// A list of IP configurations of the private endpoint. This will be used to map to the First Party Service's endpoints.
        /// </summary>
        [JsonPropertyName("ipConfigurations")]
        public IList<PrivateEndpointIPConfiguration> IpConfigurations { get; set; }

        /// <summary>
        /// The custom name of the network interface attached to the private endpoint.
        /// </summary>
        [JsonPropertyName("customNetworkInterfaceName")]
        public string CustomNetworkInterfaceName { get; set; }
    }
}