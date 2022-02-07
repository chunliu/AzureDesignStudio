using AutoMapper;
using AzureDesignStudio.Core.DTO;
using Blazor.Diagrams.Core.Geometry;
using Blazor.Diagrams.Core.Models;

namespace AzureDesignStudio.Core.Models
{
    public class AzureNodeBase : NodeModel, IAzureNode, IAzureResource
    {
        public AzureNodeBase() : base()
        {
            Size = new Size(81, 81);
        }
        public string ImagePath { get; set; } = string.Empty;

        #region IAzureNode
        public virtual string ServiceName => string.Empty;
        public virtual Type? DataFormType => throw new NotImplementedException();
        public string CssClassName => throw new NotImplementedException();
        public virtual bool IsValid => true;
        public virtual AzureNodeDto GetNodeDto(IMapper mapper)
        {
            throw new NotImplementedException();
        }
        public virtual (bool result, string message) IsDrappable(GroupModel overlappedGroup)
        {
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
        public IDictionary<string, dynamic> Properties { get; set; } = new Dictionary<string, dynamic>();

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
