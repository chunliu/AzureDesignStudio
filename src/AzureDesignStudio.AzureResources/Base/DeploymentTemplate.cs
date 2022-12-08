// Licensed under the MIT License.  See LICENSE in the project root for license information.

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Base
{
    /// <summary>
    /// An Azure deployment template
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.1.8.0")]
    public partial class DeploymentTemplate
    {
        /// <summary>
        /// JSON schema reference
        /// </summary>
        [Required]
        [JsonPropertyName("$schema")]
        [JsonPropertyOrder(1)]
        public string Schema { get; set; }

        /// <summary>
        /// Additional unstructured metadata to include with the template deployment.
        /// </summary>
        [JsonPropertyName("metadata")]
        [JsonPropertyOrder(3)]
        public object Metadata { get; set; }

        /// <summary>
        /// The apiProfile to use for all resources in the template.
        /// </summary>
        [JsonPropertyName("apiProfile")]
        [JsonPropertyOrder(4)]
        public string ApiProfile { get; set; }

        /// <summary>
        /// A 4 number format for the version number of this template file. For example, 1.0.0.0
        /// </summary>
        [Required]
        [JsonPropertyName("contentVersion")]
        [JsonPropertyOrder(2)]
        public string ContentVersion { get; set; }

        /// <summary>
        /// Variable definitions
        /// </summary>
        [JsonPropertyName("variables")]
        [JsonPropertyOrder(6)]
        public object Variables { get; set; }

        /// <summary>
        /// Input parameter definitions
        /// </summary>
        [JsonPropertyName("parameters")]
        [JsonPropertyOrder(5)]
        public IDictionary<string, Parameter> Parameters { get; set; }

        /// <summary>
        /// User defined functions
        /// </summary>
        [JsonPropertyName("functions")]
        [JsonPropertyOrder(7)]
        public IList<FunctionNamespace> Functions { get; set; }

        /// <summary>
        /// Collection of resources to be deployed
        /// </summary>
        [Required]
        [JsonPropertyName("resources")]
        [JsonPropertyOrder(8)]
        public IList<ResourceBase> Resources { get; set; }

        /// <summary>
        /// Output parameter definitions
        /// </summary>
        [JsonPropertyName("outputs")]
        [JsonPropertyOrder(9)]
        public IDictionary<string, Output> Outputs { get; set; }
    }
}