// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// FirewallPolicySQL
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class FirewallPolicySQL
    {
        /// <summary>
        /// A flag to indicate if SQL Redirect traffic filtering is enabled. Turning on the flag requires no rule using port 11000-11999.
        /// </summary>
        [JsonPropertyName("allowSqlRedirect")]
        public bool AllowSqlRedirect { get; set; }
    }
}