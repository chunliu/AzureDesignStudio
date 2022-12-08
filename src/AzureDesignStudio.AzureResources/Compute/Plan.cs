// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Compute
{
    /// <summary>
    /// Plan
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class Plan
    {
        /// <summary>
        /// The plan ID.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// The publisher ID.
        /// </summary>
        [JsonPropertyName("publisher")]
        public string Publisher { get; set; }

        /// <summary>
        /// Specifies the product of the image from the marketplace. This is the same value as Offer under the imageReference element.
        /// </summary>
        [JsonPropertyName("product")]
        public string Product { get; set; }

        /// <summary>
        /// The promotion code.
        /// </summary>
        [JsonPropertyName("promotionCode")]
        public string PromotionCode { get; set; }
    }
}