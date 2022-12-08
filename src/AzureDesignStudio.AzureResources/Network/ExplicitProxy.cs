// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// ExplicitProxy
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ExplicitProxy
    {
        /// <summary>
        /// When set to true, explicit proxy mode is enabled.
        /// </summary>
        [JsonPropertyName("enableExplicitProxy")]
        public bool EnableExplicitProxy { get; set; }

        /// <summary>
        /// Port number for explicit proxy http protocol, cannot be greater than 64000.
        /// </summary>
        [JsonPropertyName("httpPort")]
        public int HttpPort { get; set; }

        /// <summary>
        /// Port number for explicit proxy https protocol, cannot be greater than 64000.
        /// </summary>
        [JsonPropertyName("httpsPort")]
        public int HttpsPort { get; set; }

        /// <summary>
        /// When set to true, pac file port and url needs to be provided.
        /// </summary>
        [JsonPropertyName("enablePacFile")]
        public bool EnablePacFile { get; set; }

        /// <summary>
        /// Port number for firewall to serve PAC file.
        /// </summary>
        [JsonPropertyName("pacFilePort")]
        public int PacFilePort { get; set; }

        /// <summary>
        /// SAS URL for PAC file.
        /// </summary>
        [JsonPropertyName("pacFile")]
        public string PacFile { get; set; }
    }
}