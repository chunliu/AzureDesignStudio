// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Storage
{
    /// <summary>
    /// Sku
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class Sku
    {
        /// <summary>
        /// The SKU name. Required for account creation; optional for update. Note that in older versions, SKU name was called accountType.
        /// </summary>
        [Required]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The SKU tier. This is based on the SKU name.
        /// </summary>
        [JsonPropertyName("tier")]
        public string Tier { get; set; }
    }
}