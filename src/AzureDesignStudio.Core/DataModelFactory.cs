using AutoMapper;
//using AzureDesignStudio.Core.AKS;
using AzureDesignStudio.Core.APIM;
using AzureDesignStudio.Core.Web;
using AzureDesignStudio.Core.Common;
using AzureDesignStudio.Core.Components;
using AzureDesignStudio.Core.Compute;
using AzureDesignStudio.Core.DTO;
using AzureDesignStudio.Core.Models;
using AzureDesignStudio.Core.Network;
//using AzureDesignStudio.Core.ResourceGroup;
using AzureDesignStudio.Core.SQL;
using AzureDesignStudio.Core.Storage;
using Blazor.Diagrams.Core;
using Blazor.Diagrams.Core.Models;
using Blazor.Diagrams.Core.Models.Base;
using System.Text.Json;

namespace AzureDesignStudio.Core;

public static class DataModelFactory
{
    public static void RegisterAzureModels(Diagram diagram)
    {
        // AzureNodeComponent is the default componet.
        //diagram.RegisterModelComponent<ResourceGroupModel, AzureGroupComponent>();
        diagram.RegisterModelComponent<VirtualNetworkModel, AzureGroupComponent>();
        diagram.RegisterModelComponent<SubnetModel, AzureGroupComponent>();
        diagram.RegisterModelComponent<SqlServerModel, AzureGroupComponent>();
        diagram.RegisterModelComponent<AppServicePlanModel, AzureGroupComponent>();
    }
    public static NodeModel CreateNodeModelFromKey(string key, string name, string imagePath)
    {
        NodeModel result = key switch
        {
            //AdsConstants.ResourceGroup => new ResourceGroupModel(),
            AdsConstants.StorageAccount => new StorageAccountModel(),
            AdsConstants.VirtualNetwork => new VirtualNetworkModel(),
            AdsConstants.VirtualMachine => new VirtualMachineModel(),
            AdsConstants.Subnet => new SubnetModel(),
            AdsConstants.AzureFirewall => new AzureFirewallModel(),
            AdsConstants.Bastions => new BastionsModel(),
            AdsConstants.PublicIp => new PublicIpModel(),
            AdsConstants.SqlServer => new SqlServerModel(),
            AdsConstants.SqlDatabase => new SqlDatabaseModel(),
            AdsConstants.AppServicePlan => new AppServicePlanModel(),
            AdsConstants.FunctionApp => new FunctionAppModel(),
            AdsConstants.WebApp => new WebAppModel(),
            //AdsConstants.AKSCluster => new AKSModel(),
            AdsConstants.APIM => new APIMModel(),
            AdsConstants.AppGateway => new AppGatewayModel(),
            _ => throw new NotImplementedException(),
        };

        if (result is IAzureNode n)
        {
            n.ImagePath = imagePath;
        }
        if (result is IAzureResource r)
        {
            r.Name = name;
        }

        return result;
    }
    public static BaseLinkModel LinkModelFactory(Diagram diagram, PortModel sourcePort)
    {
        return sourcePort switch
        {
            VirtualNetworkPort => new LinkModel(sourcePort)
            {
                Color = "#0078d7",
                SourceMarker = LinkMarker.Arrow,
                TargetMarker = LinkMarker.Arrow,
                Width = 1,
                StrokeStyle = "dashed",
            },
            _ => new LinkModel(sourcePort)
            {
                TargetMarker = LinkMarker.Arrow,
                Width = 1,
            },
        };
    }

    public static Type? GetDtoTypeFromKey(string key)
    {
        return key switch
        {
            AdsConstants.VirtualNetwork => typeof(VirtualNetworkModelDto),
            AdsConstants.Subnet => typeof(SubnetModelDto),
            AdsConstants.Bastions => typeof(BastionsModelDto),
            AdsConstants.PublicIp => typeof(PublicIpModelDto),
            AdsConstants.AzureFirewall => typeof(AzureFirewallModelDto),
            AdsConstants.SqlServer => typeof(SqlServerModelDto),
            AdsConstants.SqlDatabase => typeof(SqlDatabaseModelDto),
            AdsConstants.AppServicePlan => typeof(AppServicePlanModelDto),
            AdsConstants.WebApp => typeof(WebAppModelDto),
            AdsConstants.FunctionApp => typeof(FunctionAppModelDto),
            AdsConstants.APIM => typeof(APIMModelDto),
            _ => throw new NotImplementedException(),
        };
    }

    public static NodeModel? GetNodeModelFromDto(AzureNodeDto dto, IMapper mapper)
    {
        return dto.TypeKey switch
        {
            AdsConstants.VirtualNetwork => mapper.Map<VirtualNetworkModel>(dto),
            AdsConstants.Subnet => mapper.Map<SubnetModel>(dto),
            AdsConstants.PublicIp => mapper.Map<PublicIpModel>(dto),
            AdsConstants.Bastions => mapper.Map<BastionsModel>(dto),
            AdsConstants.AzureFirewall => mapper.Map<AzureFirewallModel>(dto),
            AdsConstants.SqlServer => mapper.Map<SqlServerModel>(dto),
            AdsConstants.SqlDatabase => mapper.Map<SqlDatabaseModel>(dto),
            AdsConstants.AppServicePlan => mapper.Map<AppServicePlanModel>(dto),
            AdsConstants.WebApp => mapper.Map<WebAppModel>(dto),
            AdsConstants.FunctionApp => mapper.Map<FunctionAppModel>(dto),
            AdsConstants.APIM => mapper.Map<APIMModel>(dto),
            _ => throw new NotImplementedException(),
        };
    }

    public static async Task<DiagramGraph> SaveDiagramToDto(Diagram diagram, IMapper mapper)
    {
        if (diagram.Groups.Count == 0 && diagram.Nodes.Count == 0)
            return null!;

        var diagramGraph = new DiagramGraph();
        await Task.Run(() =>
        {
            // Groups
            foreach (var group in diagram.Groups)
            {
                if (group is IAzureNode n)
                {
                    diagramGraph.Groups.Add(n.GetNodeDto(mapper));
                }
            }
            // Nodes
            foreach (var node in diagram.Nodes)
            {
                if (node is IAzureNode n)
                {
                    diagramGraph.Nodes.Add(n.GetNodeDto(mapper));
                }
            }

            // Links
            foreach (var link in diagram.Links)
            {
                diagramGraph.Links.Add(mapper.Map<LinkModelDto>(link));
            }
        });

        return diagramGraph;
    }

    private static IList<AzureNodeDto>? GetNodesDto(IList<object> source)
    {
        var nodesDto = new List<AzureNodeDto>();
        foreach (var node in source)
        {
            if (node is JsonElement je)
            {
                var typeKey = je.GetProperty("TypeKey").GetString() ?? string.Empty;
                var returnType = GetDtoTypeFromKey(typeKey) 
                    ?? throw new Exception($"Cannot find the deserialization type from the type key: {typeKey}.");

                var g = JsonSerializer.Deserialize(je, returnType);
                if (g is AzureNodeDto d)
                    nodesDto.Add(d);
            }
        }
        return nodesDto;
    }

    public static void LoadDiagramFromDto(Diagram diagram, DiagramGraph diagramGraph, IMapper mapper)
    {
        diagram.SuspendRefresh = true;
        // Handle Json deserialization.
        var groupsDto = GetNodesDto(diagramGraph.Groups) ?? throw new Exception("Groups' NodesDto is null.");

        // Load all groups
        var parentGroups = groupsDto.Where(g => g is AzureNodeDto d && string.IsNullOrEmpty(d.GroupId)).ToList();
        var childGroups = groupsDto.Where(g => g is AzureNodeDto d && !string.IsNullOrEmpty(d.GroupId)).ToList();
        foreach (var parent in parentGroups)
        {
            var group = GetNodeModelFromDto(parent, mapper);
            if (group is GroupModel g)
            {
                diagram.AddGroup(g);
            }
        }
        foreach (var child in childGroups)
        {
            var node = GetNodeModelFromDto(child, mapper);
            if (node is GroupModel n)
            {
                var group = diagram.Groups.FirstOrDefault(g => g.Id == child.GroupId);
                // Sequence is important
                diagram.AddGroup(n);
                group?.AddChild(n);
            }
        }

        // Load all nodes
        var nodesDto = GetNodesDto(diagramGraph.Nodes) ?? throw new Exception("Nodes' NodesDto is null.");
        foreach (var nodeDto in nodesDto)
        {
            var node = GetNodeModelFromDto(nodeDto, mapper) ?? throw new Exception("NodeModel is null");
            diagram.Nodes.Add(node);
            if (!string.IsNullOrEmpty(nodeDto.GroupId))
            {
                var parentGroup = diagram.Groups.FirstOrDefault(g => g.Id == nodeDto.GroupId);
                parentGroup?.AddChild(node);
            }
        }

        // Load all links
        foreach (var linkDto in diagramGraph.Links)
        {
            // Search all groups first.
            NodeModel? sourceNode = diagram.Groups.FirstOrDefault(g => g.Id == linkDto.SourcePortParentId);
            sourceNode ??= diagram.Nodes.FirstOrDefault(n => n.Id == linkDto.SourcePortParentId)
                    ?? throw new Exception($"Cannot find the link's source node. SourceParentId = {linkDto.SourcePortParentId}");

            NodeModel? targetNode = diagram.Groups.FirstOrDefault(g => g.Id == linkDto.TargetPortParentId);
            targetNode ??= diagram.Nodes.FirstOrDefault(n => n.Id == linkDto.TargetPortParentId)
                    ?? throw new Exception($"Cannot find the target node. TargetParentId = {linkDto.TargetPortParentId}");

            var sourcePort = sourceNode.Ports.Single(p => p.Alignment == linkDto.SourcePortAlignment);
            var targetPort = targetNode.Ports.Single(p => p.Alignment == linkDto.TargetPortAlignment);
            var link = diagram.Options.Links.Factory(diagram, sourcePort);
            link.SetTargetPort(targetPort);
            diagram.Links.Add(link);
        }

        diagram.SuspendRefresh = false;
        diagram.Refresh();
    }
}
