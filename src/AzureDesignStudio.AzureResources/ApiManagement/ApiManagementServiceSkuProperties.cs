// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.ApiManagement
{
    /// <summary>
    /// ApiManagementServiceSkuProperties
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ApiManagementServiceSkuProperties
    {
        /// <summary>
        /// Name of the Sku.
        /// </summary>
        [Required]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Capacity of the SKU (number of deployed units of the SKU). For Consumption SKU capacity must be specified as 0.
        /// </summary>
        [Required]
        [JsonPropertyName("capacity")]
        public int Capacity { get; set; }
    }
}