using AutoMapper;
using AzureDesignStudio.AzureResources.Base;
using AzureDesignStudio.AzureResources.Network;
//using AzureDesignStudio.Core.AppService;
using AzureDesignStudio.Core.DTO;
using AzureDesignStudio.Core.Models;
//using AzureDesignStudio.Core.SQL;
using Blazor.Diagrams.Core.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AzureDesignStudio.Core.VirtualNetwork
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
        public override ResourceBase ArmResource => _subnet;
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
        private static void PopulateServiceEndpoints(NodeModel node, List<IDictionary<string, dynamic>> serviceEndpoints)
        {
            foreach (var port in node.Ports)
            {
                foreach (var link in port.Links)
                {
                    if (link.TargetPort?.Parent == node)
                        continue;

                    //if (link.TargetPort?.Parent is SqlDatabaseModel sqlDb
                    //    && serviceEndpoints.FirstOrDefault(d => d["service"] == "Microsoft.Sql") is null)
                    //{
                    //    serviceEndpoints.Add(new Dictionary<string, dynamic>
                    //        {
                    //            {"service", "Microsoft.Sql" },
                    //            {"locations", new List<string>{ sqlDb.Location } }
                    //        });
                    //}
                    //if (link.TargetPort?.Parent is WebAppModel webapp
                    //    && serviceEndpoints.FirstOrDefault(d => d["service"] == "Microsoft.Web") is null)
                    //{
                    //    serviceEndpoints.Add(new Dictionary<string, dynamic>
                    //        {
                    //            {"service", "Microsoft.Web" },
                    //            {"locations", new List<string>{ "*" } }
                    //        });
                    //}
                }
            }
        }

        protected override void PopulateArmAttributes()
        {
            base.PopulateArmAttributes();

            if (Group is not VirtualNetworkModel vnet)
                throw new Exception($"Subnet must be in a vnet.");

            ArmResource.Name = $"{vnet.Name}/{Name}";
        }

        public override IList<ResourceBase> GetArmResources()
        {
            if (Group is not VirtualNetworkModel vnet)
                throw new Exception($"Subnet must be in a vnet.");

            var serviceEndpoints = new List<IDictionary<string, dynamic>>();
            var delegations = new List<IDictionary<string, dynamic>>();
            foreach (var child in Children)
            {
                //if (child is AppServicePlanModel
                //    && delegations.FirstOrDefault(d => d["properties"]["serviceName"] == "Microsoft.Web/serverfarms") is null)
                //{
                //    delegations.Add(new Dictionary<string, dynamic>
                //    {
                //        {"name", "appsvc-delegation" },
                //        {"properties", new Dictionary<string, string>
                //            {
                //                {"serviceName", "Microsoft.Web/serverfarms" }
                //            }
                //        }
                //    });
                //}

                if (child is GroupModel group)
                {
                    foreach (var node in group.Children)
                    {
                        PopulateServiceEndpoints(node, serviceEndpoints);
                    }
                }
                else
                {
                    PopulateServiceEndpoints(child, serviceEndpoints);
                }
            }
            //Properties["serviceEndpoints"] = serviceEndpoints;
            //Properties["delegations"] = delegations;

            return base.GetArmResources();
        }

        public override AzureNodeDto GetNodeDto(IMapper mapper)
        {
            return mapper.Map<SubnetDto>(this);
        }
    }
}
