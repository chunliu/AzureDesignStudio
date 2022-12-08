// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// NatGatewaySku
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class NatGatewaySku
    {
        /// <summary>
        /// Name of Nat Gateway SKU.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}