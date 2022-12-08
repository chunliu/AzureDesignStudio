// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Storage
{
    /// <summary>
    /// ResourceAccessRule
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ResourceAccessRule
    {
        /// <summary>
        /// Tenant Id
        /// </summary>
        [JsonPropertyName("tenantId")]
        public string TenantId { get; set; }

        /// <summary>
        /// Resource Id
        /// </summary>
        [JsonPropertyName("resourceId")]
        public string ResourceId { get; set; }
    }
}