// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Compute
{
    /// <summary>
    /// SubResource
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class SubResource
    {
        /// <summary>
        /// Resource Id
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}