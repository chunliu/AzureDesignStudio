using AzureDesignStudio.Core.DTO;

namespace AzureDesignStudio.Core.SQL
{
    public class SqlServerDto : AzureNodeDto
    {
    }

    public class SqlDatabaseDto : AzureNodeDto
    {
        public string SkuName { get; set; } = null!;
        public string SkuTier { get; set; } = null!;
    }
}
