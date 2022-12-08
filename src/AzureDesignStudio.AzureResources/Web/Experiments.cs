// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Web
{
    /// <summary>
    /// Experiments
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class Experiments
    {
        /// <summary>
        /// List of ramp-up rules.
        /// </summary>
        [JsonPropertyName("rampUpRules")]
        public IList<RampUpRule> RampUpRules { get; set; }
    }
}