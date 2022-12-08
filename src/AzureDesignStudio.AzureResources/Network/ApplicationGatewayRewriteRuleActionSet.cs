// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// ApplicationGatewayRewriteRuleActionSet
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ApplicationGatewayRewriteRuleActionSet
    {
        /// <summary>
        /// Request Header Actions in the Action Set.
        /// </summary>
        [JsonPropertyName("requestHeaderConfigurations")]
        public IList<ApplicationGatewayHeaderConfiguration> RequestHeaderConfigurations { get; set; }

        /// <summary>
        /// Response Header Actions in the Action Set.
        /// </summary>
        [JsonPropertyName("responseHeaderConfigurations")]
        public IList<ApplicationGatewayHeaderConfiguration> ResponseHeaderConfigurations { get; set; }

        /// <summary>
        /// Url Configuration Action in the Action Set.
        /// </summary>
        [JsonPropertyName("urlConfiguration")]
        public ApplicationGatewayUrlConfiguration UrlConfiguration { get; set; }
    }
}