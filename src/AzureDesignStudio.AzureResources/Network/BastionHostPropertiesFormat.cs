// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Network
{
    /// <summary>
    /// BastionHostPropertiesFormat
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class BastionHostPropertiesFormat
    {
        /// <summary>
        /// IP configuration of the Bastion Host resource.
        /// </summary>
        [JsonPropertyName("ipConfigurations")]
        public IList<BastionHostIPConfiguration> IpConfigurations { get; set; }

        /// <summary>
        /// FQDN for the endpoint on which bastion host is accessible.
        /// </summary>
        [JsonPropertyName("dnsName")]
        public string DnsName { get; set; }

        /// <summary>
        /// The provisioning state of the bastion host resource.
        /// </summary>
        [JsonPropertyName("provisioningState")]
        public string ProvisioningState { get; set; }

        /// <summary>
        /// The scale units for the Bastion Host resource.
        /// </summary>
        [JsonPropertyName("scaleUnits")]
        public int ScaleUnits { get; set; }

        /// <summary>
        /// Enable/Disable Copy/Paste feature of the Bastion Host resource.
        /// </summary>
        [JsonPropertyName("disableCopyPaste")]
        public bool DisableCopyPaste { get; set; }

        /// <summary>
        /// Enable/Disable File Copy feature of the Bastion Host resource.
        /// </summary>
        [JsonPropertyName("enableFileCopy")]
        public bool EnableFileCopy { get; set; }

        /// <summary>
        /// Enable/Disable IP Connect feature of the Bastion Host resource.
        /// </summary>
        [JsonPropertyName("enableIpConnect")]
        public bool EnableIpConnect { get; set; }

        /// <summary>
        /// Enable/Disable Shareable Link of the Bastion Host resource.
        /// </summary>
        [JsonPropertyName("enableShareableLink")]
        public bool EnableShareableLink { get; set; }

        /// <summary>
        /// Enable/Disable Tunneling feature of the Bastion Host resource.
        /// </summary>
        [JsonPropertyName("enableTunneling")]
        public bool EnableTunneling { get; set; }
    }
}