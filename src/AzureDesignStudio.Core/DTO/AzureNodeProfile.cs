using AutoMapper;
//using AzureDesignStudio.Core.APIM;
using AzureDesignStudio.Core.AppService;
using AzureDesignStudio.Core.Bastions;
using AzureDesignStudio.Core.Common;
using AzureDesignStudio.Core.Firewall;
using AzureDesignStudio.Core.PublicIp;
using AzureDesignStudio.Core.SQL;
using AzureDesignStudio.Core.VirtualNetwork;
using Blazor.Diagrams.Core.Models;

namespace AzureDesignStudio.Core.DTO
{
    public class AzureNodeProfile : Profile
    {
        private void CreateMapForAzureNode<TSource, TTarget>(string typeKey) where TSource : NodeModel where TTarget : AzureNodeDto
        {
            CreateMap<TSource, TTarget>()
                .ForMember(d => d.GroupId, a => a.MapFrom(s => s.Group != null ? s.Group.Id : string.Empty))
                .AfterMap((s, d) => d.TypeKey = typeKey)
                .ReverseMap()
                .AfterMap((s, d) => d.Group = null);
        }
        public AzureNodeProfile()
        {
            CreateMap<LinkModel, LinkModelDto>()
                .ForMember(d => d.SourcePortParentId, a => a.MapFrom(s => s.SourcePort != null ? s.SourcePort.Parent.Id : string.Empty))
                .ForMember(d => d.SourcePortAlignment, a => a.MapFrom(s => s.SourcePort != null ? s.SourcePort.Alignment : PortAlignment.Bottom))
                .ForMember(d => d.TargetPortParentId, a => a.MapFrom(s => s.TargetPort != null ? s.TargetPort.Parent.Id : string.Empty))
                .ForMember(d => d.TargetPortAlignment, a => a.MapFrom(s => s.TargetPort != null ? s.TargetPort.Alignment : PortAlignment.Bottom))
                .ReverseMap();


            CreateMap<FirewallPolicyModel, FirewallPolicyDto>()
                .ReverseMap();

            CreateMap<SqlServerModel, SqlServerDto>()
                .AfterMap((s, d) => d.TypeKey = AdsConstants.SqlServer)
                .ReverseMap()
                .AfterMap((s, d) => d.Group = null);

            CreateMapForAzureNode<VirtualNetworkModel, VirtualNetworkDto>(AdsConstants.VirtualNetwork);
            CreateMapForAzureNode<SubnetModel, SubnetDto>(AdsConstants.Subnet);
            CreateMapForAzureNode<PublicIpModel, PublicIpDto>(AdsConstants.PublicIp);
            CreateMapForAzureNode<BastionsModel, BastionsDto>(AdsConstants.Bastions);
            CreateMapForAzureNode<AzureFirewallModel, AzureFirewallDto>(AdsConstants.AzureFirewall);
            CreateMapForAzureNode<SqlDatabaseModel, SqlDatabaseDto>(AdsConstants.SqlDatabase);
            CreateMapForAzureNode<AppServicePlanModel, AppServicePlanDto>(AdsConstants.AppServicePlan);
            CreateMapForAzureNode<WebAppModel, WebAppDto>(AdsConstants.WebApp);
            CreateMapForAzureNode<FunctionAppModel, FunctionAppDto>(AdsConstants.FunctionApp);
            //CreateMapForAzureNode<APIMModel, APIMDto>(AdsConstants.APIM);
        }
    }
}
