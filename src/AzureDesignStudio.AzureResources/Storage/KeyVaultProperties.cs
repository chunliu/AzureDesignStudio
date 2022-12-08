// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Storage
{
    /// <summary>
    /// KeyVaultProperties
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class KeyVaultProperties
    {
        /// <summary>
        /// The name of KeyVault key.
        /// </summary>
        [JsonPropertyName("keyname")]
        public string Keyname { get; set; }

        /// <summary>
        /// The version of KeyVault key.
        /// </summary>
        [JsonPropertyName("keyversion")]
        public string Keyversion { get; set; }

        /// <summary>
        /// The Uri of KeyVault.
        /// </summary>
        [JsonPropertyName("keyvaulturi")]
        public string Keyvaulturi { get; set; }

        /// <summary>
        /// The object identifier of the current versioned Key Vault Key in use.
        /// </summary>
        [JsonPropertyName("currentVersionedKeyIdentifier")]
        public string CurrentVersionedKeyIdentifier { get; set; }

        /// <summary>
        /// Timestamp of last rotation of the Key Vault Key.
        /// </summary>
        [JsonPropertyName("lastKeyRotationTimestamp")]
        public string LastKeyRotationTimestamp { get; set; }

        /// <summary>
        /// This is a read only property that represents the expiration time of the current version of the customer managed key used for encryption.
        /// </summary>
        [JsonPropertyName("currentVersionedKeyExpirationTimestamp")]
        public string CurrentVersionedKeyExpirationTimestamp { get; set; }
    }
}