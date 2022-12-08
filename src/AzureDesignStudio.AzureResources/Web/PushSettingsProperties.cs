// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Web
{
    /// <summary>
    /// PushSettingsProperties
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class PushSettingsProperties
    {
        /// <summary>
        /// Gets or sets a flag indicating whether the Push endpoint is enabled.
        /// </summary>
        [Required]
        [JsonPropertyName("isPushEnabled")]
        public bool IsPushEnabled { get; set; }

        /// <summary>
        /// Gets or sets a JSON string containing a list of tags that are whitelisted for use by the push registration endpoint.
        /// </summary>
        [JsonPropertyName("tagWhitelistJson")]
        public string TagWhitelistJson { get; set; }

        /// <summary>
        /// Gets or sets a JSON string containing a list of tags that require user authentication to be used in the push registration endpoint.
        [JsonPropertyName("tagsRequiringAuth")]
        public string TagsRequiringAuth { get; set; }

        /// <summary>
        /// Gets or sets a JSON string containing a list of dynamic tags that will be evaluated from user claims in the push registration endpoint.
        /// </summary>
        [JsonPropertyName("dynamicTagsJson")]
        public string DynamicTagsJson { get; set; }
    }
}