// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Web
{
    /// <summary>
    /// ConnStringInfo
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ConnStringInfo
    {
        /// <summary>
        /// Name of connection string.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Connection string value.
        /// </summary>
        [JsonPropertyName("connectionString")]
        public string ConnectionString { get; set; }

        /// <summary>
        /// Type of database.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}