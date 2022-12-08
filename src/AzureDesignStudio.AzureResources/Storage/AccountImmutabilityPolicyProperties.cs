// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Storage
{
    /// <summary>
    /// AccountImmutabilityPolicyProperties
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class AccountImmutabilityPolicyProperties
    {
        /// <summary>
        /// The immutability period for the blobs in the container since the policy creation, in days.
        /// </summary>
        [JsonPropertyName("immutabilityPeriodSinceCreationInDays")]
        public int ImmutabilityPeriodSinceCreationInDays { get; set; }

        /// <summary>
        /// The ImmutabilityPolicy state defines the mode of the policy. Disabled state disables the policy, Unlocked state allows increase and decrease of immutability retention time and also allows toggling allowProtectedAppendWrites property, Locked state only allows the increase of the immutability retention time. A policy can only be created in a Disabled or Unlocked state and can be toggled between the two states. Only a policy in an Unlocked state can transition to a Locked state which cannot be reverted.
        /// </summary>
        [JsonPropertyName("state")]
        public string State { get; set; }

        /// <summary>
        /// This property can only be changed for disabled and unlocked time-based retention policies. When enabled, new blocks can be written to an append blob while maintaining immutability protection and compliance. Only new blocks can be added and any existing blocks cannot be modified or deleted.
        /// </summary>
        [JsonPropertyName("allowProtectedAppendWrites")]
        public bool AllowProtectedAppendWrites { get; set; }
    }
}