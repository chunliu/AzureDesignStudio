// Licensed under the MIT License.  See LICENSE in the project root for license information.

using System;
using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Base
{
    [GeneratedCode("ArmTypeGenerator", "0.1.8.0")]
    public partial class ResourceBase : ARMResourceBase
    {
        /// <summary>
        /// Location to deploy resource to
        /// </summary>
        [JsonPropertyName("location")]
        [JsonPropertyOrder(-3)]
        public string Location { get; set; }

        /// <summary>
        /// Name-value pairs to add to the resource
        /// </summary>
        [JsonPropertyName("tags")]
        [JsonPropertyOrder(-2)]
        public object Tags { get; set; }
        [JsonPropertyName("copy")]
        public ResourceCopy Copy { get; set; }

        /// <summary>
        /// Scope for the resource or deployment. Today, this works for two cases: 1) setting the scope for extension resources 2) deploying resources to the tenant scope in non-tenant scope deployments
        /// </summary>
        [JsonPropertyName("scope")]
        public string Scope { get; set; }
        [JsonPropertyName("comments")]
        public string Comments { get; set; }
    }
}