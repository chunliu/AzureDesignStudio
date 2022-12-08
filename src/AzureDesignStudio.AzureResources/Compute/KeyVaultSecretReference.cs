// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Compute
{
    /// <summary>
    /// KeyVaultSecretReference
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class KeyVaultSecretReference
    {
        /// <summary>
        /// The URL referencing a secret in a Key Vault.
        /// </summary>
        [Required]
        [JsonPropertyName("secretUrl")]
        public string SecretUrl { get; set; }

        /// <summary>
        /// The relative URL of the Key Vault containing the secret.
        /// </summary>
        [Required]
        [JsonPropertyName("sourceVault")]
        public SubResource SourceVault { get; set; }
    }
}