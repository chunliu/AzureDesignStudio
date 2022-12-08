// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;
using AzureDesignStudio.AzureResources.Base;

namespace AzureDesignStudio.AzureResources.Sql
{
    /// <summary>
    /// Microsoft.Sql/servers/databases
    /// </summary>
    [AzureResource("Microsoft.Sql/servers/databases", "2022-05-01-preview")]
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class Databases : ResourceBase
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
        public override string Type => "Microsoft.Sql/servers/databases";

        /// <summary>
        /// The resource api version
        /// </summary>
        [JsonPropertyName("apiVersion")]
        public override string ApiVersion => "2022-05-01-preview";

        /// <summary>
        /// The database SKU.

        [JsonPropertyName("sku")]
        public Sku Sku { get; set; }

        /// <summary>
        /// Kind of database. This is metadata used for the Azure portal experience.
        /// </summary>
        [JsonPropertyName("kind")]
        public string Kind { get; set; }

        /// <summary>
        /// Resource that manages the database.
        /// </summary>
        [JsonPropertyName("managedBy")]
        public string ManagedBy { get; set; }

        /// <summary>
        /// The Azure Active Directory identity of the database.
        /// </summary>
        [JsonPropertyName("identity")]
        public DatabaseIdentity Identity { get; set; }

        /// <summary>
        /// Resource properties.
        /// </summary>
        [JsonPropertyName("properties")]
        public DatabaseProperties Properties { get; set; }
    }
}