// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Web
{
    /// <summary>
    /// CorsSettings
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class CorsSettings
    {
        /// <summary>
        /// Gets or sets the list of origins that should be allowed to make cross-origin
        [JsonPropertyName("allowedOrigins")]
        public IList<string> AllowedOrigins { get; set; }

        /// <summary>
        /// Gets or sets whether CORS requests with credentials are allowed. See 
        [JsonPropertyName("supportCredentials")]
        public bool SupportCredentials { get; set; }
    }
}