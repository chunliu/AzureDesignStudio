// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// PublicIPAddressSku
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class PublicIPAddressSku
    {
        /// <summary>
        /// Name of a public IP address SKU.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Tier of a public IP address SKU.
        /// </summary>
        [JsonPropertyName("tier")]
        public string Tier { get; set; }
    }
}