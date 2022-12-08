// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Compute
{
    /// <summary>
    /// PublicIPAddressSku
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class PublicIPAddressSku
    {
        /// <summary>
        /// Specify public IP sku name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// Specify public IP sku tier
        /// </summary>
        [JsonPropertyName("tier")]
        public string Tier { get; set; }
    }
}