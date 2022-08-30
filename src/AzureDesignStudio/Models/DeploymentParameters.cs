using System.ComponentModel.DataAnnotations;

namespace AzureDesignStudio.Models
{
    public record ArmParameter
    {
        public string Name { get; set; } = default!;
    }
    public record DeploymentParameters
    {
        [Required]
        public string ResourceGroup { get; set; } = default!;
        public IDictionary<string, string> Parameters { get; set; } = null!;
    }
}
