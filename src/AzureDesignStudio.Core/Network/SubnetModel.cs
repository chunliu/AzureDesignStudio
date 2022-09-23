using AutoMapper;
using AzureDesignStudio.AzureResources.Base;
using AzureDesignStudio.AzureResources.Network;
using AzureDesignStudio.Core.Web;
using AzureDesignStudio.Core.DTO;
using AzureDesignStudio.Core.Models;
using AzureDesignStudio.Core.SQL;
using Blazor.Diagrams.Core.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AzureDesignStudio.Core.Network
{
    public class SubnetModel : AzureGroupBase
    {
        public override string ServiceName => "Subnet";
        public override Type? DataFormType => null;
        public override GroupStyle GroupStyle
        {
            get => new()
            {
                OutlineColor = "#cccccc"
            };
        }
        private readonly VirtualNetworksSubnets _subnet = new()
        {
            Properties = new()
            {
                AddressPrefix = "10.0.0.0/24",
                PrivateEndpointNetworkPolicies = "Enabled",
                PrivateLinkServiceNetworkPolicies = "Enabled"
            }
        };
        protected override ResourceBase ArmResource => _subnet;
        public override string ResourceId
        {
            get
            {
                if (Group is not VirtualNetworkModel vnet)
                    throw new Exception($"Subnet needs to be in a vnet.");

                return $"[resourceId('{_subnet.Type}', '{vnet.Name}','{Name}')]";
            }
        }
        [Required, DisplayName("Address space")]
        public string AddressPrefix 
        { 
            get => _subnet.Properties.AddressPrefix; 
            set => _subnet.Properties.AddressPrefix = value; 
        }
        private static void PopulateServiceEndpoints(NodeModel node, IList<ServiceEndpointPropertiesFormat> serviceEndpoints)
        {
            foreach (var port in node.Ports)
            {
                foreach (var link in port.Links)
                {
                    if (link.TargetPort?.Parent == node)
                        continue;

                    if (link.TargetPort?.Parent is SqlDatabaseModel sqlDb
                        && serviceEndpoints.FirstOrDefault(d => d.Service == "Microsoft.Sql") is null)
                    {
                        serviceEndpoints.Add(new()
                            {
                                Service = "Microsoft.Sql",
                                Locations = new List<string>{ sqlDb.Location }
                            });
                    }
                    if (link.TargetPort?.Parent is WebAppModel webapp
                        && serviceEndpoints.FirstOrDefault(d => d.Service == "Microsoft.Web") is null)
                    {
                        serviceEndpoints.Add(new()
                            {
                                Service = "Microsoft.Web",
                                Locations = new List<string>{ "*" }
                            });
                    }
                }
            }
        }

        /*public override IList<ResourceBase> GetArmResources()
        {
            var result = base.GetArmResources().ToList();
            foreach (var child in Children)
            {
                if (child is NetworkInterfaceModel)
                {
                    var c = (NetworkInterfaceModel)child;

                    result.AddRange(c.GetArmResources());
                }
            }
            return result;
        }
        */
        protected override void PopulateArmAttributes()
        {
            base.PopulateArmAttributes();

            if (Group is not VirtualNetworkModel vnet)
                throw new Exception($"Subnet must be in a vnet.");

            ArmResource.Name = $"{vnet.Name}/{Name}";
            _subnet.Location = null;
            _subnet.DependsOn = new List<string>()
            {
                vnet.ResourceId,
            };
            _subnet.Properties.ServiceEndpoints = new List<ServiceEndpointPropertiesFormat>();
            _subnet.Properties.Delegations = new List<Delegation>();

            foreach(var child in Children)
            {
                if (child is AppServicePlanModel
                    && _subnet.Properties.Delegations.FirstOrDefault(d => d.Properties?.ServiceName == "Microsoft.Web/serverfarms") is null)
                {
                    _subnet.Properties.Delegations.Add(new()
                    {
                        Name = "appsvc-delegation",
                        Properties = new()
                        {
                            ServiceName = "Microsoft.Web/serverfarms"
                        }
                    });
                }

                if (child is GroupModel group)
                {
                    foreach (var node in group.Children)
                    {
                        PopulateServiceEndpoints(node, _subnet.Properties.ServiceEndpoints);
                    }
                }
                else
                {
                    PopulateServiceEndpoints(child, _subnet.Properties.ServiceEndpoints);
                }
            }

            // Don't include them in the serialization if they are empty. 
            if (_subnet.Properties.ServiceEndpoints.Count == 0)
                _subnet.Properties.ServiceEndpoints = null;
            if (_subnet.Properties.Delegations.Count == 0)
                _subnet.Properties.Delegations = null;
        }

        public override AzureNodeDto GetNodeDto(IMapper mapper)
        {
            return mapper.Map<SubnetDto>(this);
        }
    }
}
