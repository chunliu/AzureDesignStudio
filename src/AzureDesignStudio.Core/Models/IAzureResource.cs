using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.Core.Models
{
    public interface IAzureResource
    {
        [JsonPropertyName("id")]
        string ResourceId { get; }
        [JsonPropertyName("type")]
        string ResourceType { get; }
        string ApiVersion { get; }
        [Required, DisplayName("Name")]
        string Name { get; set; }
        [Required]
        string Location { get; set; }
        [Required, DisplayName("Region")]
        bool UseResourceGroupLocation { get; set; }
        IDictionary<string, string> Tags { get; set; }
        IDictionary<string, dynamic> Properties { get; set; }
        //IDictionary<string, dynamic> GetArmResource();
        IList<IDictionary<string, dynamic>> GetArmResources();
        IDictionary<string, dynamic> GetArmParameters();
    }
}
