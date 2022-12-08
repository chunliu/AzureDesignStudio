// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// ApplicationGatewayCustomError
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ApplicationGatewayCustomError
    {
        /// <summary>
        /// Status code of the application gateway customer error.
        /// </summary>
        [JsonPropertyName("statusCode")]
        public string StatusCode { get; set; }

        /// <summary>
        /// Error page URL of the application gateway customer error.
        /// </summary>
        [JsonPropertyName("customErrorPageUrl")]
        public string CustomErrorPageUrl { get; set; }
    }
}