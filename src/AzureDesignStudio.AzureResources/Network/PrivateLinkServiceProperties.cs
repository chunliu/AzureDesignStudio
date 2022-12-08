// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// PrivateLinkServiceProperties
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class PrivateLinkServiceProperties
    {
        /// <summary>
        /// An array of references to the load balancer IP configurations.
        /// </summary>
        [JsonPropertyName("loadBalancerFrontendIpConfigurations")]
        public IList<FrontendIPConfiguration> LoadBalancerFrontendIpConfigurations { get; set; }

        /// <summary>
        /// An array of private link service IP configurations.
        /// </summary>
        [JsonPropertyName("ipConfigurations")]
        public IList<PrivateLinkServiceIpConfiguration> IpConfigurations { get; set; }

        /// <summary>
        /// An array of references to the network interfaces created for this private link service.
        /// </summary>
        [JsonPropertyName("networkInterfaces")]
        public IList<NetworkInterface> NetworkInterfaces { get; set; }

        /// <summary>
        /// The provisioning state of the private link service resource.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }

        /// <summary>
        /// An array of list about connections to the private endpoint.
        /// </summary>
        [JsonPropertyName("privateEndpointConnections")]
        public IList<PrivateEndpointConnection> PrivateEndpointConnections { get; set; }

        /// <summary>
        /// The visibility list of the private link service.
        /// </summary>
        [JsonPropertyName("visibility")]
        public PrivateLinkServicePropertiesVisibility Visibility { get; set; }

        /// <summary>
        /// The auto-approval list of the private link service.
        /// </summary>
        [JsonPropertyName("autoApproval")]
        public PrivateLinkServicePropertiesAutoApproval AutoApproval { get; set; }

        /// <summary>
        /// The list of Fqdn.
        /// </summary>
        [JsonPropertyName("fqdns")]
        public IList<string> Fqdns { get; set; }

        /// <summary>
        /// The alias of the private link service.
        /// </summary>
        [JsonPropertyName("alias")]
        public string Alias { get; set; }

        /// <summary>
        /// Whether the private link service is enabled for proxy protocol or not.
        /// </summary>
        [JsonPropertyName("enableProxyProtocol")]
        public bool EnableProxyProtocol { get; set; }
    }
}