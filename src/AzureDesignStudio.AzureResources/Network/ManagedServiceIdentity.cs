// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// ManagedServiceIdentity
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ManagedServiceIdentity
    {
        /// <summary>
        /// The principal id of the system assigned identity. This property will only be provided for a system assigned identity.
        /// </summary>
        [JsonPropertyName("principalId")]
        public string PrincipalId { get; set; }

        /// <summary>
        /// The tenant id of the system assigned identity. This property will only be provided for a system assigned identity.
        /// </summary>
        [JsonPropertyName("tenantId")]
        public string TenantId { get; set; }

        /// <summary>
        /// The type of identity used for the resource. The type 'SystemAssigned, UserAssigned' includes both an implicitly created identity and a set of user assigned identities. The type 'None' will remove any identities from the virtual machine.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// The list of user identities associated with resource. The user identity dictionary key references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.
        /// </summary>
        [JsonPropertyName("userAssignedIdentities")]
        public ManagedServiceIdentityUserAssignedIdentities UserAssignedIdentities { get; set; }
    }
}