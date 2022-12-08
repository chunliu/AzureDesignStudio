// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Compute
{
    /// <summary>
    /// InnerError
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class InnerError
    {
        /// <summary>
        /// The exception type.
        /// </summary>
        [JsonPropertyName("exceptiontype")]
        public string Exceptiontype { get; set; }

        /// <summary>
        /// The internal error message or exception dump.
        /// </summary>
        [JsonPropertyName("errordetail")]
        public string Errordetail { get; set; }
    }
}