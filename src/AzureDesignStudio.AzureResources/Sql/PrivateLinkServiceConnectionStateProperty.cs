// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Sql
{
    /// <summary>
    /// PrivateLinkServiceConnectionStateProperty
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class PrivateLinkServiceConnectionStateProperty
    {
        /// <summary>
        /// The private link service connection status.
        /// </summary>
        [Required]
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        /// The private link service connection description.
        /// </summary>
        [Required]
        [JsonPropertyName("description")]
        public string Description { get; set; }

        /// <summary>
        /// The actions required for private link service connection.
        /// </summary>
        [JsonPropertyName("actionsRequired")]
        public string ActionsRequired { get; set; }
    }
}