// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Compute
{
    /// <summary>
    /// ApiErrorBase
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ApiErrorBase
    {
        /// <summary>
        /// The error code.
        /// </summary>
        [JsonPropertyName("code")]
        public string Code { get; set; }

        /// <summary>
        /// The target of the particular error.
        /// </summary>
        [JsonPropertyName("target")]
        public string Target { get; set; }

        /// <summary>
        /// The error message.
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}