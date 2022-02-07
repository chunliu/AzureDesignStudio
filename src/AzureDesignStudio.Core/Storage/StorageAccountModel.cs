using AzureDesignStudio.Core.Models;
using Blazor.Diagrams.Core.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace AzureDesignStudio.Core.Storage
{
    public class StorageAccountModel : AzureNodeBase
    {
        public StorageAccountModel() : base()
        {
            AddPort(PortAlignment.Left);
            AddPort(PortAlignment.Top);
            AddPort(PortAlignment.Right);
            AddPort(PortAlignment.Bottom);
        }
        public override string ServiceName => "Storage Account";
        public override string ResourceType => "Microsoft.Storage/storageAccounts";
        public override Type? DataFormType => typeof(StorageAccountForm);
        public override string ApiVersion => "2021-06-01";
        [Required, DisplayName("Sku")]
        public string SkuName { get; set; } = null!;
        [Required, DisplayName("Kind")]
        public string Kind { get; set; } = null!;
        public string AccountKey
        {
            get
            {
                Regex regex = new(@"[^\[^\]]+"); // Remove '[' and ']' from the resource id. 
                Match match = regex.Match(ResourceId);
                return $"listKeys({match.Value}, '{ApiVersion}').keys[0].value";
            }
        }

        public override IList<IDictionary<string, dynamic>> GetArmResources()
        {
            Properties.Clear();
            Properties["supportsHttpsTrafficOnly"] = true;
            Properties["minimumTlsVersion"] = "TLS1_2";

            return new List<IDictionary<string, dynamic>>
            {
                new Dictionary<string, dynamic>
                {
                    {"type", ResourceType },
                    {"apiVersion", ApiVersion },
                    {"name", Name },
                    {"location", Location },
                    {"sku", new Dictionary<string, string>{{"name", SkuName}}},
                    {"kind", Kind },
                    {"properties", Properties }
                }
            };
        }
    }
}
