// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Web
{
    /// <summary>
    /// ManagedServiceIdentity
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ManagedServiceIdentity
    {
        /// <summary>
        /// Type of managed service identity.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// Tenant of managed service identity.
        /// </summary>
        [JsonPropertyName("tenantId")]
        public string TenantId { get; set; }

        /// <summary>
        /// Principal Id of managed service identity.
        /// </summary>
        [JsonPropertyName("principalId")]
        public string PrincipalId { get; set; }

        /// <summary>
        /// The list of user assigned identities associated with the resource. The user identity dictionary key references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}
        /// </summary>
        [JsonPropertyName("userAssignedIdentities")]
        public ManagedServiceIdentityUserAssignedIdentities UserAssignedIdentities { get; set; }
    }
}