// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// ApplicationGatewayProbeHealthResponseMatch
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ApplicationGatewayProbeHealthResponseMatch
    {
        /// <summary>
        /// Body that must be contained in the health response. Default value is empty.
        /// </summary>
        [JsonPropertyName("body")]
        public string Body { get; set; }

        /// <summary>
        /// Allowed ranges of healthy status codes. Default range of healthy status codes is 200-399.
        /// </summary>
        [JsonPropertyName("statusCodes")]
        public IList<string> StatusCodes { get; set; }
    }
}