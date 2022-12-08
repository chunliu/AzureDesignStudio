// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// ServiceEndpointPolicyPropertiesFormat
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ServiceEndpointPolicyPropertiesFormat
    {
        /// <summary>
        /// A collection of service endpoint policy definitions of the service endpoint policy.
        /// </summary>
        [JsonPropertyName("serviceEndpointPolicyDefinitions")]
        public IList<ServiceEndpointPolicyDefinition> ServiceEndpointPolicyDefinitions { get; set; }

        /// <summary>
        /// A collection of references to subnets.
        /// </summary>
        [JsonPropertyName("subnets")]
        public IList<Subnet> Subnets { get; set; }

        /// <summary>
        /// The resource GUID property of the service endpoint policy resource.
        /// </summary>
        [JsonPropertyName("resourceGuid")]
        public string ResourceGuid { get; set; }

        /// <summary>
        /// The provisioning state of the service endpoint policy resource.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }

        /// <summary>
        /// The alias indicating if the policy belongs to a service
        /// </summary>
        [JsonPropertyName("serviceAlias")]
        public string ServiceAlias { get; set; }

        /// <summary>
        /// A collection of contextual service endpoint policy.
        /// </summary>
        [JsonPropertyName("contextualServiceEndpointPolicies")]
        public IList<string> ContextualServiceEndpointPolicies { get; set; }
    }
}