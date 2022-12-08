// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Storage
{
    /// <summary>
    /// StorageAccountInternetEndpoints
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class StorageAccountInternetEndpoints
    {
        /// <summary>
        /// Gets the blob endpoint.
        /// </summary>
        [JsonPropertyName("blob")]
        public string Blob { get; set; }

        /// <summary>
        /// Gets the file endpoint.
        /// </summary>
        [JsonPropertyName("file")]
        public string File { get; set; }

        /// <summary>
        /// Gets the web endpoint.
        /// </summary>
        [JsonPropertyName("web")]
        public string Web { get; set; }

        /// <summary>
        /// Gets the dfs endpoint.
        /// </summary>
        [JsonPropertyName("dfs")]
        public string Dfs { get; set; }
    }
}