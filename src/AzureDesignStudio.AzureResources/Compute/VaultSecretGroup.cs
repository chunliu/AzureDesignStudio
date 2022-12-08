// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Compute
{
    /// <summary>
    /// VaultSecretGroup
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class VaultSecretGroup
    {
        /// <summary>
        /// The relative URL of the Key Vault containing all of the certificates in VaultCertificates.
        /// </summary>
        [JsonPropertyName("sourceVault")]
        public SubResource SourceVault { get; set; }

        /// <summary>
        /// The list of key vault references in SourceVault which contain certificates.
        /// </summary>
        [JsonPropertyName("vaultCertificates")]
        public IList<VaultCertificate> VaultCertificates { get; set; }
    }
}