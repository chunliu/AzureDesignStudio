using AutoMapper;
using AzureDesignStudio.Core.DTO;
using AzureDesignStudio.Core.Models;
using Blazor.Diagrams.Core.Models;

namespace AzureDesignStudio.Core.SQL
{
    public class SqlServerModel : AzureGroupBase
    {
        public override GroupStyle GroupStyle
        {
            get => new()
            {
                OutlineWidth = 1,
                OutlineStyle = "solid",
                OutlineColor = "#8c8c8c"
            };
        }

        public override (bool result, string message) IsDrappable(GroupModel overlappedGroup)
        {
            if (overlappedGroup is IAzureNode n)
                return (false, $"Azure SQL Server cannot be deployed in the {n.ServiceName}.");

            return (true, string.Empty);
        }
        public override AzureNodeDto GetNodeDto(IMapper mapper)
        {
            return mapper.Map<SqlServerDto>(this);
        }
        public override string ServiceName => "Azure SQL Server";
        public override Type? DataFormType => typeof(SqlServerForm);
        public override string ApiVersion => "2021-05-01-preview";
        public override string ResourceType => "Microsoft.Sql/servers";
        public override IDictionary<string, dynamic> GetArmParameters()
        {  
            var sqlAdmin = new Dictionary<string, dynamic>()
            {
                {"type", "string" },
                {"metadata", new Dictionary<string, string>()
                    {
                        {"description", "User name of the administrator of the SQL server." }
                    }
                }
            };
            var adminPassword = new Dictionary<string, dynamic>()
            {
                {"type", "secureString" },
                {"metadata", new Dictionary<string, string>()
                    {
                        {"description", "Password of the administrator of the SQL server." }
                    } 
                }
            };

            return new Dictionary<string, dynamic>()
            {
                {"sqlAdmin", sqlAdmin },
                {"sqlAdminPassword", adminPassword }
            };
        }

        public override IList<IDictionary<string, dynamic>> GetArmResources()
        {
            var result = new List<IDictionary<string, dynamic>>();

            Properties.Clear();
            Properties.Add("administratorLogin", "[parameters('sqlAdmin')]");
            Properties.Add("administratorLoginPassword", "[parameters('sqlAdminPassword')]");

            result.Add(new Dictionary<string, dynamic>()
            {
                {"type", ResourceType },
                {"apiVersion", ApiVersion },
                {"name", Name},
                {"location", Location},
                {"properties", Properties },
            });

            return result;
        }
    }
}
