// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// ApplicationGatewayTrustedClientCertificatePropertiesFormat
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ApplicationGatewayTrustedClientCertificatePropertiesFormat
    {
        /// <summary>
        /// Certificate public data.
        /// </summary>
        [JsonPropertyName("data")]
        public string Data { get; set; }

        /// <summary>
        /// Validated certificate data.
        /// </summary>
        [JsonPropertyName("validatedCertData")]
        public string ValidatedCertData { get; set; }

        /// <summary>
        /// Distinguished name of client certificate issuer.
        /// </summary>
        [JsonPropertyName("clientCertIssuerDN")]
        public string ClientCertIssuerDN { get; set; }

        /// <summary>
        /// The provisioning state of the trusted client certificate resource.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }
    }
}