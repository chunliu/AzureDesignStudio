// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.ApiManagement
{
    /// <summary>
    /// ApiManagementServiceIdentity
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ApiManagementServiceIdentity
    {
        /// <summary>
        /// The type of identity used for the resource. The type 'SystemAssigned, UserAssigned' includes both an implicitly created identity and a set of user assigned identities. The type 'None' will remove any identities from the service.
        /// </summary>
        [Required]
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// The principal id of the identity.
        /// </summary>
        [JsonPropertyName("principalId")]
        public string PrincipalId { get; set; }

        /// <summary>
        /// The client tenant id of the identity.
        /// </summary>
        [JsonPropertyName("tenantId")]
        public string TenantId { get; set; }

        /// <summary>
        /// The list of user identities associated with the resource. The user identity 
        [JsonPropertyName("userAssignedIdentities")]
        public ApiManagementServiceIdentityUserAssignedIdentities UserAssignedIdentities { get; set; }
    }
}