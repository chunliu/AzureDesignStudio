// Licensed under the MIT License.  See LICENSE in the project root for license information.

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Base
{
    [GeneratedCode("ArmTypeGenerator", "0.1.8.0")]
    public partial class FunctionMember
    {
        /// <summary>
        /// Function parameters
        /// </summary>
        [JsonPropertyName("parameters")]
        public IList<FunctionParameter> Parameters { get; set; }

        /// <summary>
        /// Function output
        /// </summary>
        [JsonPropertyName("output")]
        public FunctionOutput Output { get; set; }
    }
}