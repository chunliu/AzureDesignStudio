// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Sql
{
    /// <summary>
    /// ResourceIdentity
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ResourceIdentity
    {
        /// <summary>
        /// The resource ids of the user assigned identities to use
        /// </summary>
        [JsonPropertyName("userAssignedIdentities")]
        public ResourceIdentityUserAssignedIdentities UserAssignedIdentities { get; set; }

        /// <summary>
        /// The Azure Active Directory principal id.
        /// </summary>
        [JsonPropertyName("principalId")]
        public string PrincipalId { get; set; }

        /// <summary>
        /// The identity type. Set this to 'SystemAssigned' in order to automatically create and assign an Azure Active Directory principal for the resource.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// The Azure Active Directory tenant id.
        /// </summary>
        [JsonPropertyName("tenantId")]
        public string TenantId { get; set; }
    }
}