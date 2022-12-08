// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// ApplicationGatewayRequestRoutingRulePropertiesFormat
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ApplicationGatewayRequestRoutingRulePropertiesFormat
    {
        /// <summary>
        /// Rule type.
        /// </summary>
        [JsonPropertyName("ruleType")]
        public string RuleType { get; set; }

        /// <summary>
        /// Priority of the request routing rule.
        /// </summary>
        [JsonPropertyName("priority")]
        public int Priority { get; set; }

        /// <summary>
        /// Backend address pool resource of the application gateway.
        /// </summary>
        [JsonPropertyName("backendAddressPool")]
        public SubResource BackendAddressPool { get; set; }

        /// <summary>
        /// Backend http settings resource of the application gateway.
        /// </summary>
        [JsonPropertyName("backendHttpSettings")]
        public SubResource BackendHttpSettings { get; set; }

        /// <summary>
        /// Http listener resource of the application gateway.
        /// </summary>
        [JsonPropertyName("httpListener")]
        public SubResource HttpListener { get; set; }

        /// <summary>
        /// URL path map resource of the application gateway.
        /// </summary>
        [JsonPropertyName("urlPathMap")]
        public SubResource UrlPathMap { get; set; }

        /// <summary>
        /// Rewrite Rule Set resource in Basic rule of the application gateway.
        /// </summary>
        [JsonPropertyName("rewriteRuleSet")]
        public SubResource RewriteRuleSet { get; set; }

        /// <summary>
        /// Redirect configuration resource of the application gateway.
        /// </summary>
        [JsonPropertyName("redirectConfiguration")]
        public SubResource RedirectConfiguration { get; set; }

        /// <summary>
        /// Load Distribution Policy resource of the application gateway.
        /// </summary>
        [JsonPropertyName("loadDistributionPolicy")]
        public SubResource LoadDistributionPolicy { get; set; }

        /// <summary>
        /// The provisioning state of the request routing rule resource.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }
    }
}