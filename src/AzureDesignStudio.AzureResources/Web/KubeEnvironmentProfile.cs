// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Web
{
    /// <summary>
    /// KubeEnvironmentProfile
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class KubeEnvironmentProfile
    {
        /// <summary>
        /// Resource ID of the Kubernetes Environment.
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// Name of the Kubernetes Environment.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Resource type of the Kubernetes Environment.
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}