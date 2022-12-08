// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Compute
{
    /// <summary>
    /// CapacityReservationProfile
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class CapacityReservationProfile
    {
        /// <summary>
        /// Specifies the capacity reservation group resource id that should be used for allocating the virtual machine or scaleset vm instances provided enough capacity has been reserved. Please refer to https://aka.ms/CapacityReservation for more details.
        /// </summary>
        [JsonPropertyName("capacityReservationGroup")]
        public SubResource CapacityReservationGroup { get; set; }
    }
}