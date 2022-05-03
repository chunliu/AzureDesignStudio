using AzureDesignStudio.AzureResources.Base;
using AzureDesignStudio.AzureResources.Storage;
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
        public override Type? DataFormType => typeof(StorageAccountForm);
        private readonly StorageAccounts _storageAccount = new()
        {
            Sku = new(),
            Properties = new()
            {
                SupportsHttpsTrafficOnly = true,
                MinimumTlsVersion = "TLS1_2",
            }
        };
        protected override ResourceBase ArmResource => _storageAccount;
        [Required, DisplayName("Sku")]
        public string SkuName 
        { 
            get => _storageAccount.Sku.Name; 
            set => _storageAccount.Sku.Name = value; 
        }
        [Required, DisplayName("Kind")]
        public string Kind 
        { 
            get => _storageAccount.Kind; 
            set => _storageAccount.Kind = value; 
        }
        public string AccountKey
        {
            get
            {
                Regex regex = new(@"[^\[^\]]+"); // Remove '[' and ']' from the resource id. 
                Match match = regex.Match(ResourceId);
                return $"listKeys({match.Value}, '{_storageAccount.ApiVersion}').keys[0].value";
            }
        }
    }
}
