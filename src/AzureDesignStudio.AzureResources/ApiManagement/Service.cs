// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using AzureDesignStudio.AzureResources.Base;

namespace AzureDesignStudio.AzureResources.ApiManagement
{
    /// <summary>
    /// Microsoft.ApiManagement/service
    /// </summary>
    [AzureResource("Microsoft.ApiManagement/service", "2022-04-01-preview")]
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class Service : ResourceBase
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
        public override string Type => "Microsoft.ApiManagement/service";

        /// <summary>
        /// The resource api version
        /// </summary>
        [JsonPropertyName("apiVersion")]
        public override string ApiVersion => "2022-04-01-preview";

        /// <summary>
        /// Properties of the API Management service.
        /// </summary>
        [Required]
        [JsonPropertyName("properties")]
        public ApiManagementServiceProperties Properties { get; set; }

        /// <summary>
        /// SKU properties of the API Management service.
        /// </summary>
        [Required]
        [JsonPropertyName("sku")]
        public ApiManagementServiceSkuProperties Sku { get; set; }

        /// <summary>
        /// Managed service identity of the Api Management service.
        /// </summary>
        [JsonPropertyName("identity")]
        public ApiManagementServiceIdentity Identity { get; set; }

        /// <summary>
        /// Metadata pertaining to creation and last modification of the resource.
        /// </summary>
        [JsonPropertyName("systemData")]
        public SystemData SystemData { get; set; }

        /// <summary>
        /// ETag of the resource.
        /// </summary>
        [JsonIgnore]
        public string Etag { get; private set; }

        /// <summary>
        /// A list of availability zones denoting where the resource needs to come from.
        /// </summary>
        [JsonPropertyName("zones")]
        public IList<string> Zones { get; set; }
    }
}