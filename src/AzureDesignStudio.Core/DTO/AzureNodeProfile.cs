using AutoMapper;
using AzureDesignStudio.Core.Network;
using Blazor.Diagrams.Core.Models;

namespace AzureDesignStudio.Core.DTO
{
    public partial class AzureNodeProfile : Profile
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


            CreateMap<FirewallPolicyModel, FirewallPolicyModelDto>()
                .ReverseMap();

            CreateAzureNodeMaps();
        }
        private partial void CreateAzureNodeMaps();
    }
}
