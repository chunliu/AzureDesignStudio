// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;
using AzureDesignStudio.AzureResources.Base;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// Microsoft.Network/azureFirewalls
    /// </summary>
    [AzureResource("Microsoft.Network/azureFirewalls", "2022-07-01")]
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class AzureFirewalls : ResourceBase
    {
        /// <summary>
        /// The resource id
        /// </summary>
        [JsonIgnore]
        public string Id { get; private set; }

        /// <summary>
        /// The resource type
        /// </summary>
        [JsonPropertyName("type")]
        public override string Type => "Microsoft.Network/azureFirewalls";

        /// <summary>
        /// The resource api version
        /// </summary>
        [JsonPropertyName("apiVersion")]
        public override string ApiVersion => "2022-07-01";

        /// <summary>
        /// Properties of the azure firewall.
        /// </summary>
        [JsonPropertyName("properties")]
        public AzureFirewallPropertiesFormat Properties { get; set; }

        /// <summary>
        /// A list of availability zones denoting where the resource needs to come from.
        /// </summary>
        [JsonPropertyName("zones")]
        public IList<string> Zones { get; set; }

        /// <summary>
        /// A unique read-only string that changes whenever the resource is updated.
        /// </summary>
        [JsonIgnore]
        public string Etag { get; private set; }
    }
}