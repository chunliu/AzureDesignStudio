// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// SubnetPropertiesFormat
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class SubnetPropertiesFormat
    {
        /// <summary>
        /// The address prefix for the subnet.
        /// </summary>
        [JsonPropertyName("addressPrefix")]
        public string AddressPrefix { get; set; }

        /// <summary>
        /// List of address prefixes for the subnet.
        /// </summary>
        [JsonPropertyName("addressPrefixes")]
        public IList<string> AddressPrefixes { get; set; }

        /// <summary>
        /// The reference to the NetworkSecurityGroup resource.
        /// </summary>
        [JsonPropertyName("networkSecurityGroup")]
        public NetworkSecurityGroup NetworkSecurityGroup { get; set; }

        /// <summary>
        /// The reference to the RouteTable resource.
        /// </summary>
        [JsonPropertyName("routeTable")]
        public RouteTable RouteTable { get; set; }

        /// <summary>
        /// Nat gateway associated with this subnet.
        /// </summary>
        [JsonPropertyName("natGateway")]
        public SubResource NatGateway { get; set; }

        /// <summary>
        /// An array of service endpoints.
        /// </summary>
        [JsonPropertyName("serviceEndpoints")]
        public IList<ServiceEndpointPropertiesFormat> ServiceEndpoints { get; set; }

        /// <summary>
        /// An array of service endpoint policies.
        /// </summary>
        [JsonPropertyName("serviceEndpointPolicies")]
        public IList<ServiceEndpointPolicy> ServiceEndpointPolicies { get; set; }

        /// <summary>
        /// An array of references to private endpoints.
        /// </summary>
        [JsonPropertyName("privateEndpoints")]
        public IList<PrivateEndpoint> PrivateEndpoints { get; set; }

        /// <summary>
        /// An array of references to the network interface IP configurations using subnet.
        /// </summary>
        [JsonPropertyName("ipConfigurations")]
        public IList<IPConfiguration> IpConfigurations { get; set; }

        /// <summary>
        /// Array of IP configuration profiles which reference this subnet.
        /// </summary>
        [JsonPropertyName("ipConfigurationProfiles")]
        public IList<IPConfigurationProfile> IpConfigurationProfiles { get; set; }

        /// <summary>
        /// Array of IpAllocation which reference this subnet.
        /// </summary>
        [JsonPropertyName("ipAllocations")]
        public IList<SubResource> IpAllocations { get; set; }

        /// <summary>
        /// An array of references to the external resources using subnet.
        /// </summary>
        [JsonPropertyName("resourceNavigationLinks")]
        public IList<ResourceNavigationLink> ResourceNavigationLinks { get; set; }

        /// <summary>
        /// An array of references to services injecting into this subnet.
        /// </summary>
        [JsonPropertyName("serviceAssociationLinks")]
        public IList<ServiceAssociationLink> ServiceAssociationLinks { get; set; }

        /// <summary>
        /// An array of references to the delegations on the subnet.
        /// </summary>
        [JsonPropertyName("delegations")]
        public IList<Delegation> Delegations { get; set; }

        /// <summary>
        /// A read-only string identifying the intention of use for this subnet based on delegations and other user-defined properties.
        /// </summary>
        [JsonPropertyName("purpose")]
        public string Purpose { get; set; }

        /// <summary>
        /// The provisioning state of the subnet resource.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Enable or Disable apply network policies on private end point in the subnet.
        /// </summary>
        [JsonPropertyName("privateEndpointNetworkPolicies")]
        public string PrivateEndpointNetworkPolicies { get; set; }

        /// <summary>
        /// Enable or Disable apply network policies on private link service in the subnet.
        /// </summary>
        [JsonPropertyName("privateLinkServiceNetworkPolicies")]
        public string PrivateLinkServiceNetworkPolicies { get; set; }

        /// <summary>
        /// Application gateway IP configurations of virtual network resource.
        /// </summary>
        [JsonPropertyName("applicationGatewayIpConfigurations")]
        public IList<ApplicationGatewayIPConfiguration> ApplicationGatewayIpConfigurations { get; set; }
    }
}