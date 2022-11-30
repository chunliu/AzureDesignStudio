namespace AzureDesignStudio.SourceGeneration.Tester;

public class AddressSpace
{
    // For AntList binding in UI.
    public string AddressPrefix { get; set; } = string.Empty;
}

[GenerateDto]
public class VirtualNetworkModel
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
