using AutoMapper;
using AzureDesignStudio.Core.DTO;
using AzureDesignStudio.Core.Models;
using AzureDesignStudio.Core.VirtualNetwork;
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
    public override string ResourceType => "Microsoft.ApiManagement/service";
    public override string ApiVersion => "2021-08-01";
    [Required, DisplayName("Sku Name")]
    public string SkuName { get; set; } = "Developer";
    [Required, DisplayName("Sku Capacity")]
    public int SkuCapacity { get; set; } = 1;
    [Required, DisplayName("Publisher Email")]
    public string PublisherEmail { get; set; } = null!;
    [Required, DisplayName("Publisher Name")]
    public string PublisherName { get; set;} = null!;
    [Required, DisplayName("VNET Type")]
    public string VnetType { get; set; } = "External";

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
    public override IList<IDictionary<string, dynamic>> GetArmResources()
    {
        if (!IsValid)
        {
            throw new Exception($"{ServiceName} is invalid for ARM exporting.");
        }

        var sku = new Dictionary<string, dynamic>
        {
            {"name", SkuName},
            {"capacity", SkuName == "Consumption" ? 0 : SkuCapacity },
        };

        Properties.Clear();
        Properties["publisherEmail"] = PublisherEmail;
        Properties["publisherName"] = PublisherName;

        var result = new Dictionary<string, dynamic>
        {
            {"type", ResourceType },
            {"apiVersion", ApiVersion },
            {"name", Name},
            {"location", Location},
            {"sku", sku},
            {"properties", Properties },
        };

        if (Group is SubnetModel subnet)
        {
            Properties["virtualNetworkType"] = VnetType;
            Properties["virtualNetworkConfiguration"] = new Dictionary<string, string>
            {
                {"subnetResourceId", subnet.ResourceId},
            };
            result["dependsOn"] = new List<string> { subnet.ResourceId };
        }

        return new List<IDictionary<string, dynamic>>
        {
            result,
        };
    }
}
