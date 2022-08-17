using AntDesign;
using AutoMapper;
using AzureDesignStudio.AzureResources.Base;
using AzureDesignStudio.Core.DTO;
using Blazor.Diagrams.Core.Geometry;
using Blazor.Diagrams.Core.Models;

namespace AzureDesignStudio.Core.Models
{
    public class GroupStyle
    {
        public int OutlineWidth { get; set; } = -1;
        public string? OutlineStyle { get; set; }
        public string? OutlineColor { get; set; }
        public string? BackgroundColor { get; set; }
    }
    public class AzureGroupBase : GroupModel, IAzureNode, IAzureResource
    {
        public AzureGroupBase() : base(Array.Empty<NodeModel>())
        {
            Size = new Size(141, 141);
            if (GroupStyle != null)
                BuildCSSStyle();
        }
        public string ImagePath { get; set; } = string.Empty;

        #region IAzureNode
        public virtual string ServiceName => string.Empty;
        public virtual Type? DataFormType => throw new NotImplementedException();
        public virtual string CssClassName => "ads-group";
        public virtual GroupStyle GroupStyle { get; } = null!;
        public virtual string CssStyle { get; set; } = null!;
        public void BuildCSSStyle()
        {
            if (GroupStyle == null)
                CssStyle = string.Empty;

            var styleBuilder = new CssStyleBuilder();
            if (GroupStyle?.OutlineWidth >= 0)
            {
                var width = GroupStyle.OutlineWidth.ToString() + "px";
                styleBuilder.AddStyle("--olwidth", width);
            }
            if (!string.IsNullOrEmpty(GroupStyle?.BackgroundColor))
                styleBuilder.AddStyle("--bgcolor", styleValue: GroupStyle.BackgroundColor);
            if (!string.IsNullOrEmpty(GroupStyle?.OutlineColor))
                styleBuilder.AddStyle("--olcolor", styleValue: GroupStyle.OutlineColor);
            if (!string.IsNullOrEmpty(GroupStyle?.OutlineStyle))
                styleBuilder.AddStyle("--olstyle", styleValue: GroupStyle.OutlineStyle);

            CssStyle = styleBuilder.Build();
        }
        public virtual bool IsValid => true;
        public virtual bool DataFormNoPadding => false;
        public virtual AzureNodeDto GetNodeDto(IMapper mapper)
        {
            throw new NotImplementedException();
        }
        public virtual (bool result, string message) IsDrappable(GroupModel overlappedGroup)
        {
            if (overlappedGroup is AzureGroupBase a)
                return (false, $"{ServiceName} cannot be added to {a.ServiceName}");

            return (true, string.Empty);
        }
        #endregion

        #region IAzureResource
        protected virtual ResourceBase ArmResource => throw new NotImplementedException();
        public virtual string ResourceId => $"[resourceId('{ArmResource.Type}', '{Name}')]";
        public string Name { get; set; } = string.Empty;
        public virtual string Location 
        { 
            get => UseResourceGroupLocation ? "[parameters('location')]" : ArmResource.Location;
            set => ArmResource.Location = value;
        }

        public virtual bool UseResourceGroupLocation { get; set; } = true;
        protected virtual void PopulateArmAttributes()
        {
            ArmResource.Name = Name;
            ArmResource.Location = Location;
        }

        public virtual IList<ResourceBase> GetArmResources()
        {
            PopulateArmAttributes();

            return new List<ResourceBase> { ArmResource };
        }

        public virtual IDictionary<string, Parameter> GetArmParameters()
        {
            return new Dictionary<string, Parameter>();
        }
        #endregion
    }
}
