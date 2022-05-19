using AutoMapper;
using AzureDesignStudio.AzureResources.ApiManagement;
using AzureDesignStudio.AzureResources.Base;
using AzureDesignStudio.Core.DTO;
using AzureDesignStudio.Core.Models;
using AzureDesignStudio.Core.Network;
using Blazor.Diagrams.Core.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AzureDesignStudio.Core.APIM;

public class APIMModel : AzureNodeBase
{
    public APIMModel() : base()
    {
        AddPort(PortAlignment.Left);
        AddPort(PortAlignment.Top);
        AddPort(PortAlignment.Right);
        AddPort(PortAlignment.Bottom);
    }
    public override string ServiceName => "API Management";
    public override Type? DataFormType => typeof(APIMForm);
    private readonly Service _apimService = new()
    {
        Sku = new() { Name = "Developer", Capacity = 1 },
        Properties = new()
    };
    protected override ResourceBase ArmResource => _apimService;
    [Required, DisplayName("Sku Name")]
    public string SkuName 
    { 
        get => _apimService.Sku.Name; 
        set => _apimService.Sku.Name = value; 
    }
    [Required, DisplayName("Sku Capacity")]
    public int SkuCapacity 
    { 
        get => _apimService.Sku.Capacity; 
        set => _apimService.Sku.Capacity = value; 
    }
    [Required, DisplayName("Publisher Email")]
    public string PublisherEmail 
    { 
        get => _apimService.Properties.PublisherEmail;
        set => _apimService.Properties.PublisherEmail = value; 
    }
    [Required, DisplayName("Publisher Name")]
    public string PublisherName 
    { 
        get => _apimService.Properties.PublisherName; 
        set => _apimService.Properties.PublisherName = value;
    }
    [Required, DisplayName("VNET Type")]
    public string VnetType 
    { 
        get => _apimService.Properties.VirtualNetworkType; 
        set => _apimService.Properties.VirtualNetworkType = value; 
    }

    public override bool IsValid
    {
        get => !(string.IsNullOrEmpty(PublisherName) 
            || string.IsNullOrEmpty(PublisherEmail)
            || (SkuName == "Consumption" && SkuCapacity > 0)
            || (Group is SubnetModel && (SkuName is "Consumption" or "Basic" or "Standard")));
    }

    public override (bool result, string message) IsDrappable(GroupModel overlappedGroup)
    {
        if (overlappedGroup is not null && overlappedGroup is not SubnetModel
            && overlappedGroup is IAzureNode n)
            return (false, $"{ServiceName} cannot be deployed in {n.ServiceName}.");

        return base.IsDrappable(overlappedGroup!);
    }
    public override AzureNodeDto GetNodeDto(IMapper mapper)
    {
        return mapper.Map<APIMDto>(this);
    }

    protected override void PopulateArmAttributes()
    {
        base.PopulateArmAttributes();

        if (!IsValid)
        {
            throw new Exception($"{ServiceName} is invalid for ARM exporting.");
        }

        if (Group is SubnetModel subnet)
        {
            _apimService.Properties.VirtualNetworkConfiguration = new()
            {
                SubnetResourceId = subnet.ResourceId
            };
            _apimService.DependsOn = new List<string> { subnet.ResourceId };
        }
    }
    //public override IList<IDictionary<string, dynamic>> GetArmResources()
    //{
    //    if (!IsValid)
    //    {
    //        throw new Exception($"{ServiceName} is invalid for ARM exporting.");
    //    }

    //    var sku = new Dictionary<string, dynamic>
    //    {
    //        {"name", SkuName},
    //        {"capacity", SkuName == "Consumption" ? 0 : SkuCapacity },
    //    };

    //    Properties.Clear();
    //    Properties["publisherEmail"] = PublisherEmail;
    //    Properties["publisherName"] = PublisherName;

    //    var result = new Dictionary<string, dynamic>
    //    {
    //        {"type", ResourceType },
    //        {"apiVersion", ApiVersion },
    //        {"name", Name},
    //        {"location", Location},
    //        {"sku", sku},
    //        {"properties", Properties },
    //    };

    //    if (Group is SubnetModel subnet)
    //    {
    //        Properties["virtualNetworkType"] = VnetType;
    //        Properties["virtualNetworkConfiguration"] = new Dictionary<string, string>
    //        {
    //            {"subnetResourceId", subnet.ResourceId},
    //        };
    //        result["dependsOn"] = new List<string> { subnet.ResourceId };
    //    }

    //    return new List<IDictionary<string, dynamic>>
    //    {
    //        result,
    //    };
    //}
}
