// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// ApplicationGatewayHeaderConfiguration
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ApplicationGatewayHeaderConfiguration
    {
        /// <summary>
        /// Header name of the header configuration.
        /// </summary>
        [JsonPropertyName("headerName")]
        public string HeaderName { get; set; }

        /// <summary>
        /// Header value of the header configuration.
        /// </summary>
        [JsonPropertyName("headerValue")]
        public string HeaderValue { get; set; }
    }
}