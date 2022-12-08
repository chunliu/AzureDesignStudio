// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Storage
{
    /// <summary>
    /// PrivateEndpoint
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class PrivateEndpoint
    {
        /// <summary>
        /// The ARM identifier for Private Endpoint
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}