// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.ApiManagement
{
    /// <summary>
    /// ApiVersionConstraint
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ApiVersionConstraint
    {
        /// <summary>
        /// Limit control plane API calls to API Management service with version equal to or newer than this value.
        /// </summary>
        [JsonPropertyName("minApiVersion")]
        public string MinApiVersion { get; set; }
    }
}