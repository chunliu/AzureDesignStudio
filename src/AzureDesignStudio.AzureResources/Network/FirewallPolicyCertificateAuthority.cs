// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// FirewallPolicyCertificateAuthority
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class FirewallPolicyCertificateAuthority
    {
        /// <summary>
        /// Secret Id of (base-64 encoded unencrypted pfx) 'Secret' or 'Certificate' object stored in KeyVault.
        /// </summary>
        [JsonPropertyName("keyVaultSecretId")]
        public string KeyVaultSecretId { get; set; }

        /// <summary>
        /// Name of the CA certificate.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}