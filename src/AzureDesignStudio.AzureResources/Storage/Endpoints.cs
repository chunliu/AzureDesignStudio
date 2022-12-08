// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Storage
{
    /// <summary>
    /// Endpoints
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class Endpoints
    {
        /// <summary>
        /// Gets the blob endpoint.
        /// </summary>
        [JsonPropertyName("blob")]
        public string Blob { get; set; }

        /// <summary>
        /// Gets the queue endpoint.
        /// </summary>
        [JsonPropertyName("queue")]
        public string Queue { get; set; }

        /// <summary>
        /// Gets the table endpoint.
        /// </summary>
        [JsonPropertyName("table")]
        public string Table { get; set; }

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

        /// <summary>
        /// Gets the microsoft routing storage endpoints.
        /// </summary>
        [JsonPropertyName("microsoftEndpoints")]
        public StorageAccountMicrosoftEndpoints MicrosoftEndpoints { get; set; }

        /// <summary>
        /// Gets the internet routing storage endpoints
        /// </summary>
        [JsonPropertyName("internetEndpoints")]
        public StorageAccountInternetEndpoints InternetEndpoints { get; set; }
    }
}