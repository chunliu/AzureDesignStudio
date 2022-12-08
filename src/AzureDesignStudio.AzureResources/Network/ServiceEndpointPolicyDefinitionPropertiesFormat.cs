// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// ServiceEndpointPolicyDefinitionPropertiesFormat
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ServiceEndpointPolicyDefinitionPropertiesFormat
    {
        /// <summary>
        /// A description for this rule. Restricted to 140 chars.
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// Service endpoint name.
        /// </summary>
        [JsonPropertyName("service")]
        public string Service { get; set; }

        /// <summary>
        /// A list of service resources.
        /// </summary>
        [JsonPropertyName("serviceResources")]
        public IList<string> ServiceResources { get; set; }

        /// <summary>
        /// The provisioning state of the service endpoint policy definition resource.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }
    }
}