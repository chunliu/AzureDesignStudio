using AzureDesignStudio.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureDesignStudio.Core.VirtualNetwork
{
    public class VirtualNetworkPeeringModel : IAzureResource
    {
        public string ResourceId => $"[resourceId('{ResourceType}', '{Name}')]";
        public string ResourceType => "Microsoft.Network/virtualNetworks/virtualNetworkPeerings";
        public string ApiVersion => "2021-03-01";
        public string Name { get; set; } = string.Empty;
        public string Location { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IDictionary<string, string> Tags { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IDictionary<string, dynamic> Properties { get; set; } = new Dictionary<string, dynamic>();

        public bool AllowVirtualNetworkAccess { get; set; } = true;
        public bool AllowForwardedTraffic { get; set; } = true;
        public bool AllowGatewayTransit { get; set; } = false;
        public bool UseRemoteGateways { get; set; } = false;
        public string RemoteVirtualNetworkId { get; set; } = string.Empty;
        public List<string> DependsOn { get; } = new List<string>();
        public bool UseResourceGroupLocation { get; set; } = true;

        public IDictionary<string, dynamic> GetArmParameters()
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, dynamic> GetArmResource()
        {
            Properties.Clear();

            Properties["allowVirtualNetworkAccess"] = AllowVirtualNetworkAccess;
            Properties["allowForwardedTraffic"] = AllowForwardedTraffic;
            Properties["allowGatewayTransit"] = AllowGatewayTransit;
            Properties["useRemoteGateways"] = UseRemoteGateways;
            Properties["remoteVirtualNetwork"] = new Dictionary<string, string>()
            {
                {"id", RemoteVirtualNetworkId }
            };

            var peering = new Dictionary<string, dynamic>() 
            {
                {"type", ResourceType},
                {"apiVersion", ApiVersion},
                {"name", Name},
                {"properties", Properties},
            };

            if (DependsOn.Count > 0)
                peering["dependsOn"] = DependsOn;

            return peering;
        }

        public IList<IDictionary<string, dynamic>> GetArmResources()
        {
            throw new NotImplementedException();
        }
    }
}
