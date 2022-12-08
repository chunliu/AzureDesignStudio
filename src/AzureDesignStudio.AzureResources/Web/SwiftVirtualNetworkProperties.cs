// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Web
{
    /// <summary>
    /// SwiftVirtualNetworkProperties
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class SwiftVirtualNetworkProperties
    {
        /// <summary>
        /// The Virtual Network subnet's resource ID. This is the subnet that this Web App will join. This subnet must have a delegation to Microsoft.Web/serverFarms defined first.
        /// </summary>
        [JsonPropertyName("subnetResourceId")]
        public string SubnetResourceId { get; set; }

        /// <summary>
        /// A flag that specifies if the scale unit this Web App is on supports Swift integration.
        /// </summary>
        [JsonPropertyName("swiftSupported")]
        public bool SwiftSupported { get; set; }
    }
}