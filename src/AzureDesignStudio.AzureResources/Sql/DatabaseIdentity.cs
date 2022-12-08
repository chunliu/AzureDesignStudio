// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Sql
{
    /// <summary>
    /// DatabaseIdentity
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class DatabaseIdentity
    {
        /// <summary>
        /// The identity type
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// The Azure Active Directory tenant id.
        /// </summary>
        [JsonPropertyName("tenantId")]
        public string TenantId { get; set; }

        /// <summary>
        /// The resource ids of the user assigned identities to use
        /// </summary>
        [JsonPropertyName("userAssignedIdentities")]
        public DatabaseIdentityUserAssignedIdentities UserAssignedIdentities { get; set; }
    }
}