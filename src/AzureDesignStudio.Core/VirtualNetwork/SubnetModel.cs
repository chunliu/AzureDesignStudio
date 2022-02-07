using AutoMapper;
using AzureDesignStudio.Core.AppService;
using AzureDesignStudio.Core.DTO;
using AzureDesignStudio.Core.Models;
using AzureDesignStudio.Core.SQL;
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
        public override string ResourceId
        {
            get
            {
                if (Group is not VirtualNetworkModel vnet)
                    throw new Exception($"Subnet needs to be in a vnet.");

                return $"[resourceId('{ResourceType}', '{vnet.Name}','{Name}')]";
            }
        }
        public override string ApiVersion => "2021-03-01";
        public override string ResourceType => "Microsoft.Network/virtualNetworks/subnets";
        [Required, DisplayName("Address space")]
        public string AddressPrefix { get; set; } = "10.0.0.0/24";
        private static void PopulateServiceEndpoints(NodeModel node, List<IDictionary<string, dynamic>> serviceEndpoints)
        {
            foreach (var port in node.Ports)
            {
                foreach (var link in port.Links)
                {
                    if (link.TargetPort?.Parent == node)
                        continue;

                    if (link.TargetPort?.Parent is SqlDatabaseModel sqlDb
                        && serviceEndpoints.FirstOrDefault(d => d["service"] == "Microsoft.Sql") is null)
                    {
                        serviceEndpoints.Add(new Dictionary<string, dynamic>
                            {
                                {"service", "Microsoft.Sql" },
                                {"locations", new List<string>{ sqlDb.Location } }
                            });
                    }
                    if (link.TargetPort?.Parent is WebAppModel webapp
                        && serviceEndpoints.FirstOrDefault(d => d["service"] == "Microsoft.Web") is null)
                    {
                        serviceEndpoints.Add(new Dictionary<string, dynamic>
                            {
                                {"service", "Microsoft.Web" },
                                {"locations", new List<string>{ "*" } }
                            });
                    }
                }
            }
        }
        private IDictionary<string, dynamic> GetArmResource()
        {
            if (Group is not VirtualNetworkModel vnet)
                throw new Exception($"Subnet must be in a vnet.");

            Properties.Clear();
            Properties["addressPrefix"] = AddressPrefix;
            Properties["privateEndpointNetworkPolicies"] = "Enabled";
            Properties["privateLinkServiceNetworkPolicies"] = "Enabled";

            var serviceEndpoints = new List<IDictionary<string, dynamic>>();
            var delegations = new List<IDictionary<string, dynamic>>();
            foreach(var child in Children)
            {
                if (child is AppServicePlanModel
                    && delegations.FirstOrDefault(d => d["properties"]["serviceName"] == "Microsoft.Web/serverfarms") is null)
                {
                    delegations.Add(new Dictionary<string, dynamic>
                    {
                        {"name", "appsvc-delegation" },
                        {"properties", new Dictionary<string, string>
                            {
                                {"serviceName", "Microsoft.Web/serverfarms" }
                            }
                        }
                    });
                }

                if (child is GroupModel group)
                {
                    foreach(var node in group.Children)
                    {
                        PopulateServiceEndpoints(node, serviceEndpoints);
                    }
                }
                else
                {
                    PopulateServiceEndpoints(child, serviceEndpoints);
                }
            }
            Properties["serviceEndpoints"] = serviceEndpoints;
            Properties["delegations"] = delegations;

            return new Dictionary<string, dynamic>()
            {
                {"type", ResourceType },
                {"apiVersion", ApiVersion },
                {"name", $"{vnet.Name}/{Name}" },
                {"properties", Properties },
                {"dependsOn", new List<string>()
                    {
                        vnet.ResourceId,
                    } 
                }
            };
        }

        public override IList<IDictionary<string, dynamic>> GetArmResources()
        {
            return new List<IDictionary<string, dynamic>>()
            {
                GetArmResource(),
            };
        }

        public override AzureNodeDto GetNodeDto(IMapper mapper)
        {
            return mapper.Map<SubnetDto>(this);
        }
    }
}
