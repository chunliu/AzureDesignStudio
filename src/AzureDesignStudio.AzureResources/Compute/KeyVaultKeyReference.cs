// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Compute
{
    /// <summary>
    /// KeyVaultKeyReference
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class KeyVaultKeyReference
    {
        /// <summary>
        /// The URL referencing a key encryption key in Key Vault.
        /// </summary>
        [Required]
        [JsonPropertyName("keyUrl")]
        public string KeyUrl { get; set; }

        /// <summary>
        /// The relative URL of the Key Vault containing the key.
        /// </summary>
        [Required]
        [JsonPropertyName("sourceVault")]
        public SubResource SourceVault { get; set; }
    }
}