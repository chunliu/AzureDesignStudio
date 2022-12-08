// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Web
{
    /// <summary>
    /// SkuCapacity
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class SkuCapacity
    {
        /// <summary>
        /// Minimum number of workers for this App Service plan SKU.
        /// </summary>
        [JsonPropertyName("minimum")]
        public int Minimum { get; set; }

        /// <summary>
        /// Maximum number of workers for this App Service plan SKU.
        /// </summary>
        [JsonPropertyName("maximum")]
        public int Maximum { get; set; }

        /// <summary>
        /// Maximum number of Elastic workers for this App Service plan SKU.
        /// </summary>
        [JsonPropertyName("elasticMaximum")]
        public int ElasticMaximum { get; set; }

        /// <summary>
        /// Default number of workers for this App Service plan SKU.
        /// </summary>
        [JsonPropertyName("default")]
        public int Default { get; set; }

        /// <summary>
        /// Available scale configurations for an App Service plan.
        /// </summary>
        [JsonPropertyName("scaleType")]
        public string ScaleType { get; set; }
    }
}