// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.ApiManagement
{
    /// <summary>
    /// SystemData
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class SystemData
    {
        /// <summary>
        /// The identity that created the resource.
        /// </summary>
        [JsonPropertyName("createdBy")]
        public string CreatedBy { get; set; }

        /// <summary>
        /// The type of identity that created the resource.
        /// </summary>
        [JsonPropertyName("createdByType")]
        public string CreatedByType { get; set; }

        /// <summary>
        /// The timestamp of resource creation (UTC).
        /// </summary>
        [JsonPropertyName("createdAt")]
        public string CreatedAt { get; set; }

        /// <summary>
        /// The identity that last modified the resource.
        /// </summary>
        [JsonPropertyName("lastModifiedBy")]
        public string LastModifiedBy { get; set; }

        /// <summary>
        /// The type of identity that last modified the resource.
        /// </summary>
        [JsonPropertyName("lastModifiedByType")]
        public string LastModifiedByType { get; set; }

        /// <summary>
        /// The timestamp of resource last modification (UTC)
        /// </summary>
        [JsonPropertyName("lastModifiedAt")]
        public string LastModifiedAt { get; set; }
    }
}