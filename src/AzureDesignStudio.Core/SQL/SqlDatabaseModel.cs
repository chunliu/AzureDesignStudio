using AutoMapper;
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
        public override string ApiVersion => "2021-05-01-preview";
        public override string ResourceType => "Microsoft.Sql/servers/databases";
        public override string ResourceId
        {
            get
            {
                if (Group is not SqlServerModel sqlServer)
                    throw new Exception($"SQL database must be in a SQL server.");

                return $"[resourceId('{ResourceType}', '{sqlServer.Name}','{Name}')]";
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
        public override IList<IDictionary<string, dynamic>> GetArmResources()
        {
            if (Group is not SqlServerModel sqlServer)
                throw new Exception("SQL database must be in a SQL server.");

            var result = new List<IDictionary<string, dynamic>>();

            var sku = new Dictionary<string, string>
            {
                {"name", SkuName},
                {"tier", SkuTier},
            };

            Properties.Clear();
            Properties.Add("collation", "SQL_Latin1_General_CP1_CI_AS");
            Properties.Add("maxSizeBytes", 34359738368);
            Properties.Add("catalogCollation", "SQL_Latin1_General_CP1_CI_AS");
            Properties.Add("zoneRedundant", false);
            Properties.Add("readScale", "Disabled");
            Properties.Add("highAvailabilityReplicaCount", 0);
            Properties.Add("autoPauseDelay", 60);
            Properties.Add("storageAccountType", "GRS");
            Properties.Add("minCapacity", 1);

            result.Add(new Dictionary<string, dynamic>()
            {
                {"type", ResourceType },
                {"apiVersion", ApiVersion },
                {"name", $"{sqlServer.Name}/{Name}"},
                {"location", Location},
                {"sku", sku},
                {"properties", Properties },
                {"dependsOn", new List<string>()
                    {
                        sqlServer.ResourceId,
                    } 
                }
            });

            return result;
        }
    }
}
