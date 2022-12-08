// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Web
{
    /// <summary>
    /// RampUpRule
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class RampUpRule
    {
        /// <summary>
        /// Hostname of a slot to which the traffic will be redirected if decided to. E.g. myapp-stage.azurewebsites.net.
        /// </summary>
        [JsonPropertyName("actionHostName")]
        public string ActionHostName { get; set; }

        /// <summary>
        /// Percentage of the traffic which will be redirected to <code>ActionHostName</code>.
        /// </summary>
        [JsonPropertyName("reroutePercentage")]
        public int ReroutePercentage { get; set; }

        /// <summary>
        /// In auto ramp up scenario this is the step to add/remove from <code>ReroutePercentage</code> until it reaches \n<code>MinReroutePercentage</code> or 
        [JsonPropertyName("changeStep")]
        public int ChangeStep { get; set; }

        /// <summary>
        /// Specifies interval in minutes to reevaluate ReroutePercentage.
        /// </summary>
        [JsonPropertyName("changeIntervalInMinutes")]
        public int ChangeIntervalInMinutes { get; set; }

        /// <summary>
        /// Specifies lower boundary above which ReroutePercentage will stay.
        /// </summary>
        [JsonPropertyName("minReroutePercentage")]
        public int MinReroutePercentage { get; set; }

        /// <summary>
        /// Specifies upper boundary below which ReroutePercentage will stay.
        /// </summary>
        [JsonPropertyName("maxReroutePercentage")]
        public int MaxReroutePercentage { get; set; }

        /// <summary>
        /// Custom decision algorithm can be provided in TiPCallback site extension which URL can be specified. See TiPCallback site extension for the scaffold and contracts.
        [JsonPropertyName("changeDecisionCallbackUrl")]
        public string ChangeDecisionCallbackUrl { get; set; }

        /// <summary>
        /// Name of the routing rule. The recommended name would be to point to the slot which will receive the traffic in the experiment.
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}