// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// PrivateLinkServicePropertiesVisibility
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class PrivateLinkServicePropertiesVisibility
    {
        /// <summary>
        /// The list of subscriptions.
        /// </summary>
        [JsonPropertyName("subscriptions")]
        public IList<string> Subscriptions { get; set; }
    }
}