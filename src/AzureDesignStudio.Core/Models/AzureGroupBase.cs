using AntDesign;
using AutoMapper;
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
        public virtual string ResourceId => $"[resourceId('{ResourceType}', '{Name}')]";
        public string Name { get; set; } = string.Empty;
        private string location = string.Empty;
        public virtual string Location 
        { 
            get => UseResourceGroupLocation ? "[parameters('location')]" : location;
            set => location = value;
        }
        public virtual string ResourceType => throw new NotImplementedException();

        public IDictionary<string, string> Tags { get; set; } = new Dictionary<string, string>();
        public virtual IDictionary<string, dynamic> Properties { get; set; } = new Dictionary<string, dynamic>();
        public virtual string ApiVersion => throw new NotImplementedException();

        public virtual bool UseResourceGroupLocation { get; set; } = true;

        public virtual IList<IDictionary<string, dynamic>> GetArmResources()
        {
            throw new NotImplementedException();
        }

        public virtual IDictionary<string, dynamic> GetArmParameters()
        {
            return new Dictionary<string, dynamic>();
        }
        #endregion
    }
}
