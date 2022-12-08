// Licensed under the MIT License.  See LICENSE in the project root for license information.

using System;
using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Base
{
    [GeneratedCode("ArmTypeGenerator", "0.1.8.0")]
    public partial class FunctionOutput
    {
        /// <summary>
        /// Type of function output value
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// Value assigned for function output
        /// </summary>
        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}