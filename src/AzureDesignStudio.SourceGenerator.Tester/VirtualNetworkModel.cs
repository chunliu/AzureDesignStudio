using Blazor.Diagrams.Core.Models;

namespace AzureDesignStudio.SourceGeneration.Tester;

public static class TestConstants
{
    public const string VnetKey = "VirtualNetwork";
}

public class AddressSpace
{
    // For AntList binding in UI.
    public string AddressPrefix { get; set; } = string.Empty;
}

[MapToDto(TypeKey = TestConstants.VnetKey)]
public class VirtualNetworkModel : NodeModel
{
    [MapToDto]
    public List<AddressSpace> IpSpace { get; set; } = new List<AddressSpace>()
    {
        new AddressSpace()
        {
            AddressPrefix = "10.0.0.0/16"
        }
    };
}
