// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// ApplicationGatewayPathRulePropertiesFormat
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ApplicationGatewayPathRulePropertiesFormat
    {
        /// <summary>
        /// Path rules of URL path map.
        /// </summary>
        [JsonPropertyName("paths")]
        public IList<string> Paths { get; set; }

        /// <summary>
        /// Backend address pool resource of URL path map path rule.
        /// </summary>
        [JsonPropertyName("backendAddressPool")]
        public SubResource BackendAddressPool { get; set; }

        /// <summary>
        /// Backend http settings resource of URL path map path rule.
        /// </summary>
        [JsonPropertyName("backendHttpSettings")]
        public SubResource BackendHttpSettings { get; set; }

        /// <summary>
        /// Redirect configuration resource of URL path map path rule.
        /// </summary>
        [JsonPropertyName("redirectConfiguration")]
        public SubResource RedirectConfiguration { get; set; }

        /// <summary>
        /// Rewrite rule set resource of URL path map path rule.
        /// </summary>
        [JsonPropertyName("rewriteRuleSet")]
        public SubResource RewriteRuleSet { get; set; }

        /// <summary>
        /// Load Distribution Policy resource of URL path map path rule.
        /// </summary>
        [JsonPropertyName("loadDistributionPolicy")]
        public SubResource LoadDistributionPolicy { get; set; }

        /// <summary>
        /// The provisioning state of the path rule resource.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }

        /// <summary>
        /// Reference to the FirewallPolicy resource.
        /// </summary>
        [JsonPropertyName("firewallPolicy")]
        public SubResource FirewallPolicy { get; set; }
    }
}