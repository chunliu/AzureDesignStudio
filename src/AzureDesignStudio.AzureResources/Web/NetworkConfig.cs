// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;
using AzureDesignStudio.AzureResources.Base;

namespace AzureDesignStudio.AzureResources.Web
{
    /// <summary>
    /// Microsoft.Web/sites/networkConfig
    /// </summary>
    [AzureResource("Microsoft.Web/sites/networkConfig", "2022-03-01")]
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class NetworkConfig : ResourceBase
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
        public override string Type => "Microsoft.Web/sites/networkConfig";

        /// <summary>
        /// The resource api version
        /// </summary>
        [JsonPropertyName("apiVersion")]
        public override string ApiVersion => "2022-03-01";

        /// <summary>
        /// SwiftVirtualNetwork resource specific properties
        /// </summary>
        [JsonPropertyName("properties")]
        public SwiftVirtualNetworkProperties Properties { get; set; }

        /// <summary>
        /// Kind of resource.
        /// </summary>
        [JsonPropertyName("kind")]
        public string Kind { get; set; }
    }
}