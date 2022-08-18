using AutoMapper;
using AzureDesignStudio.AzureResources.Base;
using AzureDesignStudio.AzureResources.Web;
using AzureDesignStudio.Core.DTO;
using AzureDesignStudio.Core.Models;
using AzureDesignStudio.Core.Network;
using Blazor.Diagrams.Core.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AzureDesignStudio.Core.Web
{
    public class AppServicePlanModel : AzureGroupBase
    {
        private GroupStyle groupStyle = null!;
        public override GroupStyle GroupStyle
        {
            get => groupStyle ??= new()
            {
                OutlineWidth = 0,
                BackgroundColor = "#e6f7ff",
            };
        }
        public override AzureNodeDto GetNodeDto(IMapper mapper)
        {
            return mapper.Map<AppServicePlanDto>(this);
        }
        public override (bool result, string message) IsDrappable(GroupModel overlappedGroup)
        {
            if (overlappedGroup is SubnetModel)
                return (true, string.Empty);

            return base.IsDrappable(overlappedGroup);
        }
        public override string ServiceName => "App Service Plan";
        public override Type? DataFormType => typeof(AppServicePlanForm);
        private readonly Serverfarms _servicePlan = new()
        {
            Kind = "linux",
            Sku = new()
            {
                Name = "P1v2",
                Tier = "PremiumV2",
            },
            Properties = new()
            {
                TargetWorkerCount = 1,
            }
        };
        protected override ResourceBase ArmResource => _servicePlan;
        [Required, DisplayName("OS")]
        public string Kind 
        { 
            get => _servicePlan.Kind; 
            set => _servicePlan.Kind = value; 
        }
        [Required, DisplayName("SKU Name")]
        public string SkuName 
        { 
            get => _servicePlan.Sku.Name; 
            set => _servicePlan.Sku.Name = value; 
        }
        [Required, DisplayName("Tier")]
        public string SkuTier 
        {
            get => _servicePlan.Sku.Tier;
            set
            {
                if (_servicePlan.Sku.Tier != value)
                {
                    _servicePlan.Sku.Tier = value;
                    GroupStyle.BackgroundColor = _servicePlan.Sku.Tier switch
                    {
                        "Dynamic" => "#fff2e8",
                        "ElasticPremium" => "#f6ffed",
                        _ => "#e6f7ff",
                    };
                    BuildCSSStyle();
                }
            }
        }
        protected override void PopulateArmAttributes()
        {
            base.PopulateArmAttributes();
            _servicePlan.Properties.Reserved = Kind == "linux";
        }
        //public override IList<IDictionary<string, dynamic>> GetArmResources()
        //{
        //    var result = new List<IDictionary<string, dynamic>>();

        //    var sku = new Dictionary<string, string>
        //    {
        //        {"name", SkuName},
        //        {"tier", SkuTier},
        //    };

        //    Properties.Clear();
        //    Properties["name"] = Name;
        //    Properties["numberOfWorkers"] = "1";
        //    Properties["reserved"] = Kind == "linux" ? "true" : "false";

        //    result.Add(new Dictionary<string, dynamic>()
        //    {
        //        {"type", ResourceType },
        //        {"apiVersion", ApiVersion },
        //        {"name", Name},
        //        {"location", Location},
        //        {"kind", Kind == "linux" ? Kind : ""},
        //        {"sku", sku},
        //        {"properties", Properties },
        //    });

        //    return result;
        //}
    }
}
