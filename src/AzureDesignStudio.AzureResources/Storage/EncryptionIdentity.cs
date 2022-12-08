// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Storage
{
    /// <summary>
    /// EncryptionIdentity
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class EncryptionIdentity
    {
        /// <summary>
        /// Resource identifier of the UserAssigned identity to be associated with server-side encryption on the storage account.
        /// </summary>
        [JsonPropertyName("userAssignedIdentity")]
        public string UserAssignedIdentity { get; set; }

        /// <summary>
        /// ClientId of the multi-tenant application to be used in conjunction with the user-assigned identity for cross-tenant customer-managed-keys server-side encryption on the storage account.
        /// </summary>
        [JsonPropertyName("federatedIdentityClientId")]
        public string FederatedIdentityClientId { get; set; }
    }
}