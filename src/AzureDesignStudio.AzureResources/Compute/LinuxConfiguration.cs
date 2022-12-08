// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Compute
{
    /// <summary>
    /// LinuxConfiguration
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class LinuxConfiguration
    {
        /// <summary>
        /// Specifies whether password authentication should be disabled.
        /// </summary>
        [JsonPropertyName("disablePasswordAuthentication")]
        public bool DisablePasswordAuthentication { get; set; }

        /// <summary>
        /// Specifies the ssh key configuration for a Linux OS.
        /// </summary>
        [JsonPropertyName("ssh")]
        public SshConfiguration Ssh { get; set; }

        /// <summary>
        /// Indicates whether virtual machine agent should be provisioned on the virtual machine. <br><br> When this property is not specified in the request body, default behavior is to set it to true.  This will ensure that VM Agent is installed on the VM so that extensions can be added to the VM later.
        /// </summary>
        [JsonPropertyName("provisionVMAgent")]
        public bool ProvisionVMAgent { get; set; }

        /// <summary>
        /// [Preview Feature] Specifies settings related to VM Guest Patching on Linux.
        /// </summary>
        [JsonPropertyName("patchSettings")]
        public LinuxPatchSettings PatchSettings { get; set; }

        /// <summary>
        /// Indicates whether VMAgent Platform Updates is enabled for the Linux virtual machine. Default value is false.
        /// </summary>
        [JsonPropertyName("enableVMAgentPlatformUpdates")]
        public bool EnableVMAgentPlatformUpdates { get; set; }
    }
}