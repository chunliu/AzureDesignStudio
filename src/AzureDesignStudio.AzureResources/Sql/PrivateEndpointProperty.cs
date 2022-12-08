// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Sql
{
    /// <summary>
    /// PrivateEndpointProperty
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class PrivateEndpointProperty
    {
        /// <summary>
        /// Resource id of the private endpoint.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}