// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Compute
{
    /// <summary>
    /// ApplicationProfile
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class ApplicationProfile
    {
        /// <summary>
        /// Specifies the gallery applications that should be made available to the VM/VMSS
        /// </summary>
        [JsonPropertyName("galleryApplications")]
        public IList<VMGalleryApplication> GalleryApplications { get; set; }
    }
}