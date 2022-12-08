// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// ApplicationGatewayRewriteRuleCondition
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ApplicationGatewayRewriteRuleCondition
    {
        /// <summary>
        /// The condition parameter of the RewriteRuleCondition.
        /// </summary>
        [JsonPropertyName("variable")]
        public string Variable { get; set; }

        /// <summary>
        /// The pattern, either fixed string or regular expression, that evaluates the truthfulness of the condition.
        /// </summary>
        [JsonPropertyName("pattern")]
        public string Pattern { get; set; }

        /// <summary>
        /// Setting this parameter to truth value with force the pattern to do a case in-sensitive comparison.
        /// </summary>
        [JsonPropertyName("ignoreCase")]
        public bool IgnoreCase { get; set; }

        /// <summary>
        /// Setting this value as truth will force to check the negation of the condition given by the user.
        /// </summary>
        [JsonPropertyName("negate")]
        public bool Negate { get; set; }
    }
}