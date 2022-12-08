// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using AzureDesignStudio.AzureResources.Base;

namespace AzureDesignStudio.AzureResources.Storage
{
    /// <summary>
    /// Microsoft.Storage/storageAccounts
    /// </summary>
    [AzureResource("Microsoft.Storage/storageAccounts", "2022-09-01")]
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class StorageAccounts : ResourceBase
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
        public override string Type => "Microsoft.Storage/storageAccounts";

        /// <summary>
        /// The resource api version
        /// </summary>
        [JsonPropertyName("apiVersion")]
        public override string ApiVersion => "2022-09-01";

        /// <summary>
        /// Required. Gets or sets the SKU name.
        /// </summary>
        [Required]
        [JsonPropertyName("sku")]
        public Sku Sku { get; set; }

        /// <summary>
        /// Required. Indicates the type of storage account.
        /// </summary>
        [Required]
        [JsonPropertyName("kind")]
        public string Kind { get; set; }

        /// <summary>
        /// Optional. Set the extended location of the resource. If not set, the storage account will be created in Azure main region. Otherwise it will be created in the specified extended location
        /// </summary>
        [JsonPropertyName("extendedLocation")]
        public ExtendedLocation ExtendedLocation { get; set; }

        /// <summary>
        /// The identity of the resource.
        /// </summary>
        [JsonPropertyName("identity")]
        public Identity Identity { get; set; }

        /// <summary>
        /// The parameters used to create the storage account.
        /// </summary>
        [JsonPropertyName("properties")]
        public StorageAccountPropertiesCreateParametersOrStorageAccountProperties Properties { get; set; }
    }
}