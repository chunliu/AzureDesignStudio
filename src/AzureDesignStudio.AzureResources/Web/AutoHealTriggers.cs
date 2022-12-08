// Licensed under the MIT License. See LICENSE in the project root for license information.

using System.CodeDom.Compiler;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.AzureResources.Web
{
    /// <summary>
    /// AutoHealTriggers
    /// </summary>
    [GeneratedCode("ArmTypeGenerator", "0.2.1.52938")]
    public partial class AutoHealTriggers
    {
        /// <summary>
        /// A rule based on total requests.
        /// </summary>
        [JsonPropertyName("requests")]
        public RequestsBasedTrigger Requests { get; set; }

        /// <summary>
        /// A rule based on private bytes.
        /// </summary>
        [JsonPropertyName("privateBytesInKB")]
        public int PrivateBytesInKB { get; set; }

        /// <summary>
        /// A rule based on status codes.
        /// </summary>
        [JsonPropertyName("statusCodes")]
        public IList<StatusCodesBasedTrigger> StatusCodes { get; set; }

        /// <summary>
        /// A rule based on request execution time.
        /// </summary>
        [JsonPropertyName("slowRequests")]
        public SlowRequestsBasedTrigger SlowRequests { get; set; }

        /// <summary>
        /// A rule based on multiple Slow Requests Rule with path
        /// </summary>
        [JsonPropertyName("slowRequestsWithPath")]
        public IList<SlowRequestsBasedTrigger> SlowRequestsWithPath { get; set; }

        /// <summary>
        /// A rule based on status codes ranges.
        /// </summary>
        [JsonPropertyName("statusCodesRange")]
        public IList<StatusCodesRangeBasedTrigger> StatusCodesRange { get; set; }
    }
}