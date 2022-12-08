// Licensed under the MIT License.  See LICENSE in the project root for license information.

using System;
using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Base
{
    /// <summary>
    /// Output copy
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.1.8.0")]
    public partial class OutputCopy
    {
        /// <summary>
        /// Count of the copy
        /// </summary>
        [Required]
        [JsonPropertyName("count")]
        public string Count { get; set; }

        /// <summary>
        /// Input of the copy
        /// </summary>
        [Required]
        [JsonPropertyName("input")]
        public string Input { get; set; }
    }
}