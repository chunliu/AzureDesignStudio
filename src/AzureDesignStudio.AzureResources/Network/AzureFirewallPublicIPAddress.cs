// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// AzureFirewallPublicIPAddress
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class AzureFirewallPublicIPAddress
    {
        /// <summary>
        /// Public IP Address value.
        /// </summary>
        [JsonPropertyName("address")]
        public string Address { get; set; }
    }
}