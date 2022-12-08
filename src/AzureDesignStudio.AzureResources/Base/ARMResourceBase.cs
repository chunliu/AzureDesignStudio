// Licensed under the MIT License.  See LICENSE in the project root for license information.

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Base
{
    [GeneratedCode("ArmTypeGenerator", "0.1.8.0")]
    public partial class ARMResourceBase
    {
        /// <summary>
        /// Name of the resource
        /// </summary>
        [Required]
        [JsonPropertyName("name")]
        [JsonPropertyOrder(-6)]
        public string Name { get; set; }

        /// <summary>
        /// Resource type
        /// </summary>
        [Required]
        [JsonPropertyName("type")]
        [JsonPropertyOrder(-5)]
        public virtual string Type => throw new NotImplementedException();

        /// <summary>
        /// Condition of the resource
        /// </summary>
        [JsonPropertyName("condition")]
        public string Condition { get; set; }

        /// <summary>
        /// API Version of the resource type, optional when apiProfile is used on the template
        /// </summary>
        [JsonPropertyName("apiVersion")]
        [JsonPropertyOrder(-4)]
        public virtual string ApiVersion => throw new NotImplementedException();

        /// <summary>
        /// Collection of resources this resource depends on
        /// </summary>
        [JsonPropertyName("dependsOn")]
        [JsonPropertyOrder(-1)]
        public IList<string> DependsOn { get; set; }
    }
}