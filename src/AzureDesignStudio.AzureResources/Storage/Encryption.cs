// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Storage
{
    /// <summary>
    /// Encryption
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class Encryption
    {
        /// <summary>
        /// List of services which support encryption.
        /// </summary>
        [JsonPropertyName("services")]
        public EncryptionServices Services { get; set; }

        /// <summary>
        /// The encryption keySource (provider). Possible values (case-insensitive):  Microsoft.Storage, Microsoft.Keyvault
        /// </summary>
        [JsonPropertyName("keySource")]
        public string KeySource { get; set; }

        /// <summary>
        /// A boolean indicating whether or not the service applies a secondary layer of encryption with platform managed keys for data at rest.
        /// </summary>
        [JsonPropertyName("requireInfrastructureEncryption")]
        public bool RequireInfrastructureEncryption { get; set; }

        /// <summary>
        /// Properties provided by key vault.
        /// </summary>
        [JsonPropertyName("keyvaultproperties")]
        public KeyVaultProperties Keyvaultproperties { get; set; }

        /// <summary>
        /// The identity to be used with service-side encryption at rest.
        /// </summary>
        [JsonPropertyName("identity")]
        public EncryptionIdentity Identity { get; set; }
    }
}