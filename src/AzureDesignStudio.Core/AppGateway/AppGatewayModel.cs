using AzureDesignStudio.Core.Models;
using AzureDesignStudio.Core.PublicIp;
using AzureDesignStudio.Core.VirtualNetwork;
using Blazor.Diagrams.Core.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AzureDesignStudio.Core.AppGateway;

public class AppGatewayModel : AzureNodeBase
{
    public AppGatewayModel() : base()
    {
        AddPort(PortAlignment.Left);
        AddPort(PortAlignment.Top);
        AddPort(PortAlignment.Right);
        AddPort(PortAlignment.Bottom);
    }

    public override string ServiceName => "Application Gateway";
    public override Type? DataFormType => typeof(AppGatewayForm);
    public override (bool result, string message) IsDrappable(GroupModel overlappedGroup)
    {
        if (overlappedGroup is not SubnetModel)
            return (false, $"{ServiceName} must be deployed in a subnet.");

        return base.IsDrappable(overlappedGroup);
    }
    private PublicIpModel? GetPip()
    {
        foreach(var port in Ports)
        {
            foreach(var link in port.Links)
            {
                if (link.SourcePort?.Parent == this)
                    continue;

                if (link.SourcePort?.Parent is PublicIpModel pip)
                    return pip;
            }
        }

        return null;
    }
    public override bool IsValid
    {
        get
        {
            if (GetPip() is null)
                return false;

            return true;
        }
    }
    public override string ResourceType => "Microsoft.Network/applicationGateways";
    public override string ApiVersion => "2021-05-01";
    [Required, DisplayName("Tier")]
    public string Tier { get; set; } = "Standard_v2";
    public string BackendPoolName { get; set; } = null!;
    public string BackendAddressType { get; set; } = "fqdn";
    public string BackendAddress { get; set; } = null!;
}
