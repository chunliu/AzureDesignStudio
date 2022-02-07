namespace AzureDesignStudio.Core.DTO
{
    public class DiagramGraph
    {
        // Use `object` for Json serialziation. https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-polymorphism
        public IList<object> Groups { get; set; } = new List<object>();
        public IList<object> Nodes { get; set; } = new List<object>();
        public IList<LinkModelDto> Links { get; set; } = new List<LinkModelDto>();
    }
}
