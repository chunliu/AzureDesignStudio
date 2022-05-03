using AutoMapper;
using AzureDesignStudio.AzureResources.Base;
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
