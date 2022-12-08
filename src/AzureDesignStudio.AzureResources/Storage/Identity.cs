// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Storage
{
    /// <summary>
    /// Identity
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class Identity
    {
        /// <summary>
        /// The principal ID of resource identity.
        /// </summary>
        [JsonPropertyName("principalId")]
        public string PrincipalId { get; set; }

        /// <summary>
        /// The tenant ID of resource.
        /// </summary>
        [JsonPropertyName("tenantId")]
        public string TenantId { get; set; }

        /// <summary>
        /// The identity type.
        /// </summary>
        [Required]
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets a list of key value pairs that describe the set of User Assigned identities that will be used with this storage account. The key is the ARM resource identifier of the identity. Only 1 User Assigned identity is permitted here.
        /// </summary>
        [JsonPropertyName("userAssignedIdentities")]
        public IdentityUserAssignedIdentities UserAssignedIdentities { get; set; }
    }
}