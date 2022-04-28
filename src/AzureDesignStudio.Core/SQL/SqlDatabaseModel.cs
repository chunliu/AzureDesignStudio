using AutoMapper;
using AzureDesignStudio.AzureResources.Base;
using AzureDesignStudio.AzureResources.Sql;
using AzureDesignStudio.Core.DTO;
using AzureDesignStudio.Core.Models;
using Blazor.Diagrams.Core.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AzureDesignStudio.Core.SQL
{
    public class SqlDatabaseModel : AzureNodeBase
    {
        public SqlDatabaseModel() : base()
        {
            AddPort(PortAlignment.Left);
            AddPort(PortAlignment.Top);
            AddPort(PortAlignment.Right);
            AddPort(PortAlignment.Bottom);
        }
        public override string ServiceName => "Azure SQL Database";
        public override Type? DataFormType => typeof(SqlDatabaseForm);
        public override (bool result, string message) IsDrappable(GroupModel overlappedGroup)
        {
            if (overlappedGroup is not SqlServerModel)
                return (false, $"Azure SQL Database can only be deployed in an Azure SQL Server");

            return base.IsDrappable(overlappedGroup);
        }
        private readonly Servers_databases _database = new();
        public override ResourceBase ArmResource => _database;
        public override string ResourceId
        {
            get
            {
                if (Group is not SqlServerModel sqlServer)
                    throw new Exception($"SQL database must be in a SQL server.");

                return $"[resourceId('{_database.Type}', '{sqlServer.Name}','{Name}')]";
            }
        }
        [Required, DisplayName("SKU Name")]
        public string SkuName { get; set; } = "GP_Gen5_2";
        [Required, DisplayName("Tier")]
        public string SkuTier { get; set; } = "GeneralPurpose";

        public override AzureNodeDto GetNodeDto(IMapper mapper)
        {
            return mapper.Map<SqlDatabaseDto>(this);
        }
        protected override void PopulateArmAttributes()
        {
            base.PopulateArmAttributes();

            if (Group is not SqlServerModel sqlServer)
                throw new Exception("SQL database must be in a SQL server.");

            _database.Name = $"{sqlServer.Name}/{Name}";

            _database.Sku = new()
            {
                Name = SkuName,
                Tier = SkuTier,
            };

            _database.Properties = new()
            {
                Collation = "SQL_Latin1_General_CP1_CI_AS",
                CatalogCollation = "SQL_Latin1_General_CP1_CI_AS",
            };

            _database.DependsOn = new List<string> { sqlServer.ResourceId };
        }
    }
}
