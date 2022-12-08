// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.ApiManagement
{
    /// <summary>
    /// CertificateConfiguration
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class CertificateConfiguration
    {
        /// <summary>
        /// Base64 Encoded certificate.
        /// </summary>
        [JsonPropertyName("encodedCertificate")]
        public string EncodedCertificate { get; set; }

        /// <summary>
        /// Certificate Password.
        /// </summary>
        [JsonPropertyName("certificatePassword")]
        public string CertificatePassword { get; set; }

        /// <summary>
        /// The System.Security.Cryptography.x509certificates.StoreName certificate store location. Only Root and CertificateAuthority are valid locations.
        /// </summary>
        [Required]
        [JsonPropertyName("storeName")]
        public string StoreName { get; set; }

        /// <summary>
        /// Certificate information.
        /// </summary>
        [JsonPropertyName("certificate")]
        public CertificateInformation Certificate { get; set; }
    }
}