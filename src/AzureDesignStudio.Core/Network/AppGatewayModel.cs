using AzureDesignStudio.AzureResources.Base;
using AzureDesignStudio.AzureResources.Network;
using AzureDesignStudio.Core.Models;
using Blazor.Diagrams.Core.Models;
using Blazor.Diagrams.Core.Models.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AzureDesignStudio.Core.Network;

public class AppGatewayModel : AzureNodeBase
{
    public AppGatewayModel() : base()
    {
        var leftPort = AddPort(PortAlignment.Left);
        leftPort.OnLinkAdded += PortLinkAdded;
        leftPort.OnLinkRemoved += PortLinkRemoved;

        var topPort = AddPort(PortAlignment.Top);
        topPort.OnLinkAdded += PortLinkAdded;
        topPort.OnLinkRemoved += PortLinkRemoved;

        var rightPort = AddPort(PortAlignment.Right);
        rightPort.OnLinkAdded += PortLinkAdded;
        rightPort.OnLinkRemoved += PortLinkRemoved;

        var bottomPort = AddPort(PortAlignment.Bottom);
        bottomPort.OnLinkAdded += PortLinkAdded;
        bottomPort.OnLinkRemoved += PortLinkRemoved;
    }

    public override string ServiceName => "Application Gateway";
    public override Type? DataFormType => typeof(AppGatewayForm);
    public override (bool result, string message) IsDrappable(GroupModel overlappedGroup)
    {
        if (overlappedGroup is not SubnetModel)
            return (false, $"{ServiceName} must be deployed in a subnet.");

        return base.IsDrappable(overlappedGroup);
    }
    private List<PublicIpModel>? _pips = null;
    private void PortLinkAdded(PortModel port, BaseLinkModel link)
    {
        if (link.SourcePort?.Parent is PublicIpModel pip)
        {
            if (_pips == null)
                _pips = new List<PublicIpModel>();

            if (!_pips.Exists(p => p.ResourceId == pip.ResourceId))
            {
                _pips.Add(pip);
                Refresh();
            }
        }
    }
    private void PortLinkRemoved(PortModel port, BaseLinkModel link)
    {
        if (link.SourcePort?.Parent is PublicIpModel pip
            && (_pips?.Exists(p => p.ResourceId == pip.ResourceId) ?? false))
        {
            _pips.Remove(pip);
            Refresh();
        }
    }
    public override bool IsValid
    {
        get => _pips?.Count > 0;
    }
    public override bool DataFormNoPadding => true;

    private readonly ApplicationGateways _appGateway = new()
    {
        Properties = new()
        {
            Sku = new()
            {
                Name = "Standard_v2",
                Tier = "Standard_v2",
                Capacity = 2
            },
            AutoscaleConfiguration = new()
            {
                MinCapacity = 0,
                MaxCapacity = 10
            }
        },
    };
    protected override ResourceBase ArmResource => _appGateway;
    [Required, DisplayName("Tier")]
    public string Tier 
    { 
        get => _appGateway.Properties.Sku.Tier; 
        set
        {
            _appGateway.Properties.Sku.Tier = value;
            _appGateway.Properties.Sku.Name = value;
        }
    }
    [DisplayName("Autoscaling")]
    public bool Autoscaling { get; set; } = false;
    [DisplayName("Instance")]
    public int InstanceCount 
    { 
        get => _appGateway.Properties.Sku.Capacity; 
        set => _appGateway.Properties.Sku.Capacity = value; 
    }
    [DisplayName("Min Instance")]
    public int MinCapacity 
    { 
        get => _appGateway.Properties.AutoscaleConfiguration.MinCapacity; 
        set => _appGateway.Properties.AutoscaleConfiguration.MinCapacity = value; 
    }
    [DisplayName("Max Instance")]
    public int MaxCapacity
    {
        get => _appGateway.Properties.AutoscaleConfiguration.MaxCapacity;
        set => _appGateway.Properties.AutoscaleConfiguration.MaxCapacity = value;
    }
    public string BackendPoolName { get; set; } = null!;
    public string BackendAddressType { get; set; } = "fqdn";
    public string BackendAddress { get; set; } = null!;
}
