// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// ApplicationGatewaySslProfilePropertiesFormat
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ApplicationGatewaySslProfilePropertiesFormat
    {
        /// <summary>
        /// Array of references to application gateway trusted client certificates.
        /// </summary>
        [JsonPropertyName("trustedClientCertificates")]
        public IList<SubResource> TrustedClientCertificates { get; set; }

        /// <summary>
        /// SSL policy of the application gateway resource.
        /// </summary>
        [JsonPropertyName("sslPolicy")]
        public ApplicationGatewaySslPolicy SslPolicy { get; set; }

        /// <summary>
        /// Client authentication configuration of the application gateway resource.
        /// </summary>
        [JsonPropertyName("clientAuthConfiguration")]
        public ApplicationGatewayClientAuthConfiguration ClientAuthConfiguration { get; set; }

        /// <summary>
        /// The provisioning state of the HTTP listener resource.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }
    }
}