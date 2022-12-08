// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// ApplicationGatewayUrlPathMapPropertiesFormat
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ApplicationGatewayUrlPathMapPropertiesFormat
    {
        /// <summary>
        /// Default backend address pool resource of URL path map.
        /// </summary>
        [JsonPropertyName("defaultBackendAddressPool")]
        public SubResource DefaultBackendAddressPool { get; set; }

        /// <summary>
        /// Default backend http settings resource of URL path map.
        /// </summary>
        [JsonPropertyName("defaultBackendHttpSettings")]
        public SubResource DefaultBackendHttpSettings { get; set; }

        /// <summary>
        /// Default Rewrite rule set resource of URL path map.
        /// </summary>
        [JsonPropertyName("defaultRewriteRuleSet")]
        public SubResource DefaultRewriteRuleSet { get; set; }

        /// <summary>
        /// Default redirect configuration resource of URL path map.
        /// </summary>
        [JsonPropertyName("defaultRedirectConfiguration")]
        public SubResource DefaultRedirectConfiguration { get; set; }

        /// <summary>
        /// Default Load Distribution Policy resource of URL path map.
        /// </summary>
        [JsonPropertyName("defaultLoadDistributionPolicy")]
        public SubResource DefaultLoadDistributionPolicy { get; set; }

        /// <summary>
        /// Path rule of URL path map resource.
        /// </summary>
        [JsonPropertyName("pathRules")]
        public IList<ApplicationGatewayPathRule> PathRules { get; set; }

        /// <summary>
        /// The provisioning state of the URL path map resource.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }
    }
}