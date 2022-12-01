using Blazor.Diagrams.Core.Geometry;

namespace AzureDesignStudio.Core.DTO
{
    public class AzureNodeDto
    {
        public string TypeKey { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        // Key data from NodeModel
        public string Id { get; set; } = string.Empty;
        public bool Locked { get; set; }
        public Point Position { get; set; } = Point.Zero;
        public Size Size { get; set; } = Size.Zero;
        public string GroupId { get; set; } = string.Empty;
        // Data for Azure resources
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public bool UseResourceGroupLocation { get; set; }
    }
}
