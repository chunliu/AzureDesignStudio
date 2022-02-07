namespace AzureDesignStudio.Models
{
    public class StencilModel
    {
        public string Key { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string IconPath { get; set; } = string.Empty;
        public string Label { get; set; } = string.Empty;
        public StencilCategory Category { get; set; }
    }

    public enum StencilCategory
    {
        Networking = 0,
        Compute,
        Database,
        Storage,
        Others
    }
}
