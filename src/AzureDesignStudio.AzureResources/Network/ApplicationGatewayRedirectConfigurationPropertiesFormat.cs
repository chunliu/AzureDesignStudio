// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// ApplicationGatewayRedirectConfigurationPropertiesFormat
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ApplicationGatewayRedirectConfigurationPropertiesFormat
    {
        /// <summary>
        /// HTTP redirection type.
        /// </summary>
        [JsonPropertyName("redirectType")]
        public string RedirectType { get; set; }

        /// <summary>
        /// Reference to a listener to redirect the request to.
        /// </summary>
        [JsonPropertyName("targetListener")]
        public SubResource TargetListener { get; set; }

        /// <summary>
        /// Url to redirect the request to.
        /// </summary>
        [JsonPropertyName("targetUrl")]
        public string TargetUrl { get; set; }

        /// <summary>
        /// Include path in the redirected url.
        /// </summary>
        [JsonPropertyName("includePath")]
        public bool IncludePath { get; set; }

        /// <summary>
        /// Include query string in the redirected url.
        /// </summary>
        [JsonPropertyName("includeQueryString")]
        public bool IncludeQueryString { get; set; }

        /// <summary>
        /// Request routing specifying redirect configuration.
        /// </summary>
        [JsonPropertyName("requestRoutingRules")]
        public IList<SubResource> RequestRoutingRules { get; set; }

        /// <summary>
        /// Url path maps specifying default redirect configuration.
        /// </summary>
        [JsonPropertyName("urlPathMaps")]
        public IList<SubResource> UrlPathMaps { get; set; }

        /// <summary>
        /// Path rules specifying redirect configuration.
        /// </summary>
        [JsonPropertyName("pathRules")]
        public IList<SubResource> PathRules { get; set; }
    }
}