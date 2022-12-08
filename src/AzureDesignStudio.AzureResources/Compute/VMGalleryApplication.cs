// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Compute
{
    /// <summary>
    /// VMGalleryApplication
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class VMGalleryApplication
    {
        /// <summary>
        /// Optional, Specifies a passthrough value for more generic context.
        /// </summary>
        [JsonPropertyName("tags")]
        public string Tags { get; set; }

        /// <summary>
        /// Optional, Specifies the order in which the packages have to be installed
        /// </summary>
        [JsonPropertyName("order")]
        public int Order { get; set; }

        /// <summary>
        /// Specifies the GalleryApplicationVersion resource id on the form of /subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/providers/Microsoft.Compute/galleries/{galleryName}/applications/{application}/versions/{version}
        /// </summary>
        [Required]
        [JsonPropertyName("packageReferenceId")]
        public string PackageReferenceId { get; set; }

        /// <summary>
        /// Optional, Specifies the uri to an azure blob that will replace the default configuration for the package if provided
        /// </summary>
        [JsonPropertyName("configurationReference")]
        public string ConfigurationReference { get; set; }

        /// <summary>
        /// Optional, If true, any failure for any operation in the VmApplication will fail the deployment
        /// </summary>
        [JsonPropertyName("treatFailureAsDeploymentFailure")]
        public bool TreatFailureAsDeploymentFailure { get; set; }

        /// <summary>
        /// If set to true, when a new Gallery Application version is available in PIR/SIG, it will be automatically updated for the VM/VMSS
        /// </summary>
        [JsonPropertyName("enableAutomaticUpgrade")]
        public bool EnableAutomaticUpgrade { get; set; }
    }
}