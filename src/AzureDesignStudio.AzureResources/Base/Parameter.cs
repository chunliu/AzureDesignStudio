// Licensed under the MIT License.  See LICENSE in the project root for license information.

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Base
{
    /// <summary>
    /// Input parameter definitions
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.1.8.0")]
    public partial class Parameter
    {
        /// <summary>
        /// Type of input parameter
        /// </summary>
        [Required]
        [JsonPropertyName("type")]
        public string Type { get; set; }

        /// <summary>
        /// Default value to be used if one is not provided
        /// </summary>
        [JsonPropertyName("defaultValue")]
        public string DefaultValue { get; set; }

        /// <summary>
        /// Value can only be one of these values
        /// </summary>
        [JsonPropertyName("allowedValues")]
        public IList<object> AllowedValues { get; set; }

        /// <summary>
        /// Metadata for the parameter, can be any valid JSON object
        /// </summary>
        [JsonPropertyName("metadata")]
        public object Metadata { get; set; }

        /// <summary>
        /// Minimum value for the int type parameter
        /// </summary>
        [JsonPropertyName("minValue")]
        public int MinValue { get; set; }

        /// <summary>
        /// Maximum value for the int type parameter
        /// </summary>
        [JsonPropertyName("maxValue")]
        public int MaxValue { get; set; }

        /// <summary>
        /// Minimum length for the string or array type parameter
        /// </summary>
        [JsonPropertyName("minLength")]
        public int MinLength { get; set; }

        /// <summary>
        /// Maximum length for the string or array type parameter
        /// </summary>
        [JsonPropertyName("maxLength")]
        public int MaxLength { get; set; }
    }
}