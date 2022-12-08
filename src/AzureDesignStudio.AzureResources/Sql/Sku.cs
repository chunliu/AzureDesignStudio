// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Sql
{
    /// <summary>
    /// Sku
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class Sku
    {
        /// <summary>
        /// The name of the SKU, typically, a letter + Number code, e.g. P3.
        /// </summary>
        [Required]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The tier or edition of the particular SKU, e.g. Basic, Premium.
        /// </summary>
        [JsonPropertyName("tier")]
        public string Tier { get; set; }

        /// <summary>
        /// Size of the particular SKU
        /// </summary>
        [JsonPropertyName("size")]
        public string Size { get; set; }

        /// <summary>
        /// If the service has different generations of hardware, for the same SKU, then that can be captured here.
        /// </summary>
        [JsonPropertyName("family")]
        public string Family { get; set; }

        /// <summary>
        /// Capacity of the particular SKU.
        /// </summary>
        [JsonPropertyName("capacity")]
        public int Capacity { get; set; }
    }
}