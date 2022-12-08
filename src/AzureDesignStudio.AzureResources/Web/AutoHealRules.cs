// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Web
{
    /// <summary>
    /// AutoHealRules
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class AutoHealRules
    {
        /// <summary>
        /// Conditions that describe when to execute the auto-heal actions.
        /// </summary>
        [JsonPropertyName("triggers")]
        public AutoHealTriggers Triggers { get; set; }

        /// <summary>
        /// Actions to be executed when a rule is triggered.
        /// </summary>
        [JsonPropertyName("actions")]
        public AutoHealActions Actions { get; set; }
    }
}