// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;
using AzureDesignStudio.AzureResources.Base;

namespace AzureDesignStudio.AzureResources.Web
{
    /// <summary>
    /// Microsoft.Web/serverfarms
    /// </summary>
    [AzureResource("Microsoft.Web/serverfarms", "2022-03-01")]
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class Serverfarms : ResourceBase
    {
        /// <summary>
        /// The resource id
        /// </summary>
        [JsonIgnore]
        public string Id { get; private set; }

        /// <summary>
        /// The resource type
        /// </summary>
        [JsonPropertyName("type")]
        public override string Type => "Microsoft.Web/serverfarms";

        /// <summary>
        /// The resource api version
        /// </summary>
        [JsonPropertyName("apiVersion")]
        public override string ApiVersion => "2022-03-01";

        /// <summary>
        /// AppServicePlan resource specific properties
        /// </summary>
        [JsonPropertyName("properties")]
        public AppServicePlanProperties Properties { get; set; }

        /// <summary>
        /// Description of a SKU for a scalable resource.
        /// </summary>
        [JsonPropertyName("sku")]
        public SkuDescription Sku { get; set; }

        /// <summary>
        /// Extended Location.
        /// </summary>
        [JsonPropertyName("extendedLocation")]
        public ExtendedLocation ExtendedLocation { get; set; }

        /// <summary>
        /// Kind of resource.
        /// </summary>
        [JsonPropertyName("kind")]
        public string Kind { get; set; }
    }
}