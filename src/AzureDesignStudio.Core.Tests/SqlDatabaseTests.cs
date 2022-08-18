using AzureDesignStudio.Core.Models;
using AzureDesignStudio.Core.SQL;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace AzureDesignStudio.Core.Tests
{
    public class SqlDatabaseTests : TestBase
    {
        public SqlDatabaseTests() : base() { }

        [Fact]
        public async Task SqlServerTest()
        {
            var armTemplate = new ArmTemplate();

            var sqlServer = new SqlServerModel()
            {
                Name = "azsqlserver"
            };

            var parameters = new Dictionary<string, dynamic>()
            {
                {"sqlAdmin", new Dictionary<string, string>()
                    {
                        {"value", "dbadmin" }
                    }
                },
                {"sqlAdminPassword", new Dictionary<string, string>()
                    {
                        {"value", "password" }
                    }
                }
            };

            string p = JsonSerializer.Serialize(parameters,
                new JsonSerializerOptions(JsonSerializerDefaults.Web)
                {
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    WriteIndented = true,
                }
            );

            armTemplate.AddParameters(sqlServer.GetArmParameters());
            armTemplate.AddResource(sqlServer.GetArmResources());

            var validateRes = await ValidateTemplate(armTemplate, p);
            Assert.Null(validateRes?.Error);
        }

        [Fact]
        public async Task SqlDatabaseTest()
        {
            var armTemplate = new ArmTemplate();

            var sqlServer = new SqlServerModel()
            {
                Name = "azsqlserver"
            };

            var parameters = new Dictionary<string, dynamic>()
            {
                {"sqlAdmin", new Dictionary<string, string>()
                    {
                        {"value", "dbadmin" }
                    }
                },
                {"sqlAdminPassword", new Dictionary<string, string>()
                    {
                        {"value", "password" }
                    }
                }
            };

            string p = JsonSerializer.Serialize(parameters,
                new JsonSerializerOptions(JsonSerializerDefaults.Web)
                {
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    WriteIndented = true,
                }
            );

            armTemplate.AddParameters(sqlServer.GetArmParameters());
            armTemplate.AddResource(sqlServer.GetArmResources());

            var sqlDatabase = new SqlDatabaseModel()
            {
                Name = "azsqldb1",
                Group = sqlServer,
            };

            armTemplate.AddResource(sqlDatabase.GetArmResources());

            var validateRes = await ValidateTemplate(armTemplate, p);
            Assert.Null(validateRes?.Error);
        }

    }
}
