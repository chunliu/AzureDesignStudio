// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// ApplicationGatewayRewriteRuleSetPropertiesFormat
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ApplicationGatewayRewriteRuleSetPropertiesFormat
    {
        /// <summary>
        /// Rewrite rules in the rewrite rule set.
        /// </summary>
        [JsonPropertyName("rewriteRules")]
        public IList<ApplicationGatewayRewriteRule> RewriteRules { get; set; }

        /// <summary>
        /// The provisioning state of the rewrite rule set resource.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }
    }
}