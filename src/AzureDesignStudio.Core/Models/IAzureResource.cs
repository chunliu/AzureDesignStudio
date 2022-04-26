using AzureDesignStudio.AzureResources.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AzureDesignStudio.Core.Models
{
    public interface IAzureResource
    {
        ResourceBase ArmResource { get; }
        [JsonPropertyName("id")]
        string ResourceId { get; }
        [Required, DisplayName("Name")]
        string Name { get; set; }
        [Required]
        string Location { get; set; }
        [Required, DisplayName("Region")]
        bool UseResourceGroupLocation { get; set; }
        //IDictionary<string, dynamic> GetArmResource();
        IList<ResourceBase> GetArmResources();
        IDictionary<string, Parameter> GetArmParameters();
    }
}
