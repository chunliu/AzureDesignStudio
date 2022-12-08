// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;
using AzureDesignStudio.AzureResources.Base;

namespace AzureDesignStudio.AzureResources.Compute
{
    /// <summary>
    /// Microsoft.Compute/virtualMachines
    /// </summary>
    [AzureResource("Microsoft.Compute/virtualMachines", "2022-08-01")]
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class VirtualMachines : ResourceBase
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
        public override string Type => "Microsoft.Compute/virtualMachines";

        /// <summary>
        /// The resource api version
        /// </summary>
        [JsonPropertyName("apiVersion")]
        public override string ApiVersion => "2022-08-01";

        /// <summary>
        /// Specifies information about the marketplace image used to create the virtual machine. This element is only used for marketplace images. Before you can use a marketplace image from an API, you must enable the image for programmatic use.  In the Azure portal, find the marketplace image that you want to use and then click **Want to deploy programmatically, Get Started ->**. Enter any required information and then click **Save**.
        /// </summary>
        [JsonPropertyName("plan")]
        public Plan Plan { get; set; }

        /// <summary>
        /// Describes the properties of a Virtual Machine.
        /// </summary>
        [JsonPropertyName("properties")]
        public VirtualMachineProperties Properties { get; set; }

        /// <summary>
        /// The virtual machine child extension resources.
        /// </summary>
        [JsonPropertyName("resources")]
        public IList<VirtualMachineExtension> Resources { get; set; }

        /// <summary>
        /// The identity of the virtual machine, if configured.
        /// </summary>
        [JsonPropertyName("identity")]
        public VirtualMachineIdentity Identity { get; set; }

        /// <summary>
        /// The virtual machine zones.
        /// </summary>
        [JsonPropertyName("zones")]
        public IList<string> Zones { get; set; }

        /// <summary>
        /// The extended location of the Virtual Machine.
        /// </summary>
        [JsonPropertyName("extendedLocation")]
        public ExtendedLocation ExtendedLocation { get; set; }
    }
}