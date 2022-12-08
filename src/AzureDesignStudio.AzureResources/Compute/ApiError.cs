// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Compute
{
    /// <summary>
    /// ApiError
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ApiError
    {
        /// <summary>
        /// The Api error details
        /// </summary>
        [JsonPropertyName("details")]
        public IList<ApiErrorBase> Details { get; set; }

        /// <summary>
        /// The Api inner error
        /// </summary>
        [JsonPropertyName("innererror")]
        public InnerError Innererror { get; set; }

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