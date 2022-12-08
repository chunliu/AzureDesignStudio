// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// ApplicationGatewayRewriteRule
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ApplicationGatewayRewriteRule
    {
        /// <summary>
        /// Name of the rewrite rule that is unique within an Application Gateway.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Rule Sequence of the rewrite rule that determines the order of execution of a particular rule in a RewriteRuleSet.
        /// </summary>
        [JsonPropertyName("ruleSequence")]
        public int RuleSequence { get; set; }

        /// <summary>
        /// Conditions based on which the action set execution will be evaluated.
        /// </summary>
        [JsonPropertyName("conditions")]
        public IList<ApplicationGatewayRewriteRuleCondition> Conditions { get; set; }

        /// <summary>
        /// Set of actions to be done as part of the rewrite Rule.
        /// </summary>
        [JsonPropertyName("actionSet")]
        public ApplicationGatewayRewriteRuleActionSet ActionSet { get; set; }
    }
}