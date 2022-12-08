// Licensed under the MIT License.  See LICENSE in the project root for license information.

using System;
using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Base
{
    [GeneratedCode("ArmTypeGenerator", "0.1.8.0")]
    public partial class FunctionParameter
    {
        /// <summary>
        /// Function parameter name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Type of function parameter value
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}