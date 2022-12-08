// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// ResourceNavigationLinkFormat
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ResourceNavigationLinkFormat
    {
        /// <summary>
        /// Resource type of the linked resource.
        /// </summary>
        [JsonPropertyName("linkedResourceType")]
        public string LinkedResourceType { get; set; }

        /// <summary>
        /// Link to the external resource.
        /// </summary>
        [JsonPropertyName("link")]
        public string Link { get; set; }

        /// <summary>
        /// The provisioning state of the resource navigation link resource.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }
    }
}