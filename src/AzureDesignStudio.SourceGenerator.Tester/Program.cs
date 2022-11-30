
using AzureDesignStudio.SourceGeneration.Tester;

var dto = new VirtualNetworkModelDto 
{ 
    Name = "vnet",
    IpSpace = new List<AddressSpace>
    {
        new AddressSpace()
        {
            AddressPrefix = "10.0.0.0/16"
        }
    }
};

Console.WriteLine(dto.Name);
