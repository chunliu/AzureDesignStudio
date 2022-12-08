// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Compute
{
    /// <summary>
    /// DiskEncryptionSettings
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class DiskEncryptionSettings
    {
        /// <summary>
        /// Specifies the location of the disk encryption key, which is a Key Vault Secret.
        /// </summary>
        [JsonPropertyName("diskEncryptionKey")]
        public KeyVaultSecretReference DiskEncryptionKey { get; set; }

        /// <summary>
        /// Specifies the location of the key encryption key in Key Vault.
        /// </summary>
        [JsonPropertyName("keyEncryptionKey")]
        public KeyVaultKeyReference KeyEncryptionKey { get; set; }

        /// <summary>
        /// Specifies whether disk encryption should be enabled on the virtual machine.
        /// </summary>
        [JsonPropertyName("enabled")]
        public bool Enabled { get; set; }
    }
}