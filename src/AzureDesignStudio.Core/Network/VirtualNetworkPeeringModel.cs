using AzureDesignStudio.AzureResources.Base;
using AzureDesignStudio.AzureResources.Network;
using AzureDesignStudio.Core.Models;

namespace AzureDesignStudio.Core.Network
{
    public class VirtualNetworkPeeringModel : IAzureResource
    {
        private readonly VirtualNetworkPeerings _virtualNetworkPeerings = new()
        {
            Properties = new()
            {
                AllowVirtualNetworkAccess = true,
                AllowForwardedTraffic = true,
                AllowGatewayTransit = true,
                UseRemoteGateways = false,
            },
            DependsOn = new List<string>()
        };
        public ResourceBase ArmResource => _virtualNetworkPeerings;
        public string ResourceId => $"[resourceId('{_virtualNetworkPeerings.Type}', '{_virtualNetworkPeerings.Name}')]";
        public string Name
        {
            get => _virtualNetworkPeerings.Name;
            set => _virtualNetworkPeerings.Name = value;
        }
        public string Location { get => _virtualNetworkPeerings.Location; set => _virtualNetworkPeerings.Location = value; }

        public string RemoteVirtualNetworkId
        {
            get => _virtualNetworkPeerings.Properties.RemoteVirtualNetwork.Id;
            set => _virtualNetworkPeerings.Properties.RemoteVirtualNetwork = new SubResource { Id = value };
        }
        public IList<string> DependsOn => _virtualNetworkPeerings.DependsOn;
        public bool UseResourceGroupLocation { get; set; } = true;

        public IDictionary<string, Parameter> GetArmParameters()
        {
            throw new NotImplementedException();
        }

        public IList<ResourceBase> GetArmResources()
        {
            throw new NotImplementedException();
        }
    }
}
