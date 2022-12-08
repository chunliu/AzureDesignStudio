// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.ApiManagement
{
    /// <summary>
    /// CertificateInformation
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class CertificateInformation
    {
        /// <summary>
        /// Expiration date of the certificate. The date conforms to the following format: `yyyy-MM-ddTHH:mm:ssZ` as specified by the ISO 8601 standard.
        /// </summary>
        [Required]
        [JsonPropertyName("expiry")]
        public string Expiry { get; set; }

        /// <summary>
        /// Thumbprint of the certificate.
        /// </summary>
        [Required]
        [JsonPropertyName("thumbprint")]
        public string Thumbprint { get; set; }

        /// <summary>
        /// Subject of the certificate.
        /// </summary>
        [Required]
        [JsonPropertyName("subject")]
        public string Subject { get; set; }
    }
}