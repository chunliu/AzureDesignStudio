// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// ApplicationGatewaySslCertificatePropertiesFormat
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ApplicationGatewaySslCertificatePropertiesFormat
    {
        /// <summary>
        /// Base-64 encoded pfx certificate. Only applicable in PUT Request.
        /// </summary>
        [JsonPropertyName("data")]
        public string Data { get; set; }

        /// <summary>
        /// Password for the pfx file specified in data. Only applicable in PUT request.
        /// </summary>
        [JsonPropertyName("password")]
        public string Password { get; set; }

        /// <summary>
        /// Base-64 encoded Public cert data corresponding to pfx specified in data. Only applicable in GET request.
        /// </summary>
        [JsonPropertyName("publicCertData")]
        public string PublicCertData { get; set; }

        /// <summary>
        /// Secret Id of (base-64 encoded unencrypted pfx) 'Secret' or 'Certificate' object stored in KeyVault.
        /// </summary>
        [JsonPropertyName("keyVaultSecretId")]
        public string KeyVaultSecretId { get; set; }

        /// <summary>
        /// The provisioning state of the SSL certificate resource.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }
    }
}