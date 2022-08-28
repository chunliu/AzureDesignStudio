namespace AzureDesignStudio.Models
{
    public record ArmParameter
    {
        public string Name { get; set; } = default!;
    }
    public record DeploymentParameters
    {
        public string ResourceGroup { get; set; } = default!;
        public IDictionary<string, string> Parameters { get; set; } = null!;
    }
}
