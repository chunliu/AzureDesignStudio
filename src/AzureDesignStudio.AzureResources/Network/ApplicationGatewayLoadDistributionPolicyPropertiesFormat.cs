// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// ApplicationGatewayLoadDistributionPolicyPropertiesFormat
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ApplicationGatewayLoadDistributionPolicyPropertiesFormat
    {
        /// <summary>
        /// Load Distribution Targets resource of an application gateway.
        /// </summary>
        [JsonPropertyName("loadDistributionTargets")]
        public IList<ApplicationGatewayLoadDistributionTarget> LoadDistributionTargets { get; set; }

        /// <summary>
        /// Load Distribution Targets resource of an application gateway.
        /// </summary>
        [JsonPropertyName("loadDistributionAlgorithm")]
        public string LoadDistributionAlgorithm { get; set; }

        /// <summary>
        /// The provisioning state of the Load Distribution Policy resource.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }
    }
}