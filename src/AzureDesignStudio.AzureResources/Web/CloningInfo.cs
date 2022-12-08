// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Web
{
    /// <summary>
    /// CloningInfo
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class CloningInfo
    {
        /// <summary>
        /// Correlation ID of cloning operation. This ID ties multiple cloning operations
        [JsonPropertyName("correlationId")]
        public string CorrelationId { get; set; }

        /// <summary>
        /// <code>true</code> to overwrite destination app; otherwise, <code>false</code>.
        /// </summary>
        [JsonPropertyName("overwrite")]
        public bool Overwrite { get; set; }

        /// <summary>
        /// <code>true</code> to clone custom hostnames from source app; otherwise, <code>false</code>.
        /// </summary>
        [JsonPropertyName("cloneCustomHostNames")]
        public bool CloneCustomHostNames { get; set; }

        /// <summary>
        /// <code>true</code> to clone source control from source app; otherwise, <code>false</code>.
        /// </summary>
        [JsonPropertyName("cloneSourceControl")]
        public bool CloneSourceControl { get; set; }

        /// <summary>
        /// ARM resource ID of the source app. App resource ID is of the form 
        [Required]
        [JsonPropertyName("sourceWebAppId")]
        public string SourceWebAppId { get; set; }

        /// <summary>
        /// Location of source app ex: West US or North Europe
        /// </summary>
        [JsonPropertyName("sourceWebAppLocation")]
        public string SourceWebAppLocation { get; set; }

        /// <summary>
        /// App Service Environment.
        /// </summary>
        [JsonPropertyName("hostingEnvironment")]
        public string HostingEnvironment { get; set; }

        /// <summary>
        /// Application setting overrides for cloned app. If specified, these settings override the settings cloned 
        [JsonPropertyName("appSettingsOverrides")]
        public CloningInfoAppSettingsOverrides AppSettingsOverrides { get; set; }

        /// <summary>
        /// <code>true</code> to configure load balancing for source and destination app.
        /// </summary>
        [JsonPropertyName("configureLoadBalancing")]
        public bool ConfigureLoadBalancing { get; set; }

        /// <summary>
        /// ARM resource ID of the Traffic Manager profile to use, if it exists. Traffic Manager resource ID is of the form 
        [JsonPropertyName("trafficManagerProfileId")]
        public string TrafficManagerProfileId { get; set; }

        /// <summary>
        /// Name of Traffic Manager profile to create. This is only needed if Traffic Manager profile does not already exist.
        /// </summary>
        [JsonPropertyName("trafficManagerProfileName")]
        public string TrafficManagerProfileName { get; set; }
    }
}