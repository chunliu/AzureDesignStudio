// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// ApplicationGatewayClientAuthConfiguration
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ApplicationGatewayClientAuthConfiguration
    {
        /// <summary>
        /// Verify client certificate issuer name on the application gateway.
        /// </summary>
        [JsonPropertyName("verifyClientCertIssuerDN")]
        public bool VerifyClientCertIssuerDN { get; set; }

        /// <summary>
        /// Verify client certificate revocation status.
        /// </summary>
        [JsonPropertyName("verifyClientRevocation")]
        public string VerifyClientRevocation { get; set; }
    }
}