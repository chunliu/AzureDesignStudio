// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Compute
{
    /// <summary>
    /// ImageReference
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ImageReference
    {
        /// <summary>
        /// The image publisher.
        /// </summary>
        [JsonPropertyName("publisher")]
        public string Publisher { get; set; }

        /// <summary>
        /// Specifies the offer of the platform image or marketplace image used to create the virtual machine.
        /// </summary>
        [JsonPropertyName("offer")]
        public string Offer { get; set; }

        /// <summary>
        /// The image SKU.
        /// </summary>
        [JsonPropertyName("sku")]
        public string Sku { get; set; }

        /// <summary>
        /// Specifies the version of the platform image or marketplace image used to create the virtual machine. The allowed formats are Major.Minor.Build or 'latest'. Major, Minor, and Build are decimal numbers. Specify 'latest' to use the latest version of an image available at deploy time. Even if you use 'latest', the VM image will not automatically update after deploy time even if a new version becomes available. Please do not use field 'version' for gallery image deployment, gallery image should always use 'id' field for deployment, to use 'latest' version of gallery image, just set '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/galleries/{galleryName}/images/{imageName}' in the 'id' field without version input.
        /// </summary>
        [JsonPropertyName("version")]
        public string Version { get; set; }

        /// <summary>
        /// Specifies in decimal numbers, the version of platform image or marketplace image used to create the virtual machine. This readonly field differs from 'version', only if the value specified in 'version' field is 'latest'.
        /// </summary>
        [JsonPropertyName("exactVersion")]
        public string ExactVersion { get; set; }

        /// <summary>
        /// Specified the shared gallery image unique id for vm deployment. This can be fetched from shared gallery image GET call.
        /// </summary>
        [JsonPropertyName("sharedGalleryImageId")]
        public string SharedGalleryImageId { get; set; }

        /// <summary>
        /// Specified the community gallery image unique id for vm deployment. This can be fetched from community gallery image GET call.
        /// </summary>
        [JsonPropertyName("communityGalleryImageId")]
        public string CommunityGalleryImageId { get; set; }

        /// <summary>
        /// Resource Id
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}