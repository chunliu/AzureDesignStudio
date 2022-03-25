using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.Json.Schema;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace AzureDesignStudio.CodeGeneration
{
    class Program
    {
        /// <summary>
        /// main entrypoint
        /// </summary>
        /// <returns></returns>
        static async Task Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please enter output path for generated class files");
                return;
            }

            var outputDirectoryPath = args[0];

            if (!Directory.Exists(outputDirectoryPath))
            {
                Console.WriteLine("directory path '" + outputDirectoryPath + "' does not exist, please create it before running this command");
                return;
            }

            // list of schemas that we don't want to generate classes for (THB...)
            List<string> excludedResourceDefinitions = new List<string> {
                "Microsoft.Compute.Extensions",
                "Microsoft.Insights.ManuallyAuthored",
                "Microsoft.Solutions",
                "Microsoft.Kusto",
                "Microsoft.Authorization.Resources"
            };

            // list of ARM deploymentTempalte schemas
            var rootSchemaUriList = new List<string> {
                "https://schema.management.azure.com/schemas/2015-01-01/deploymentTemplate.json#",
                "https://schema.management.azure.com/schemas/2019-04-01/deploymentTemplate.json#"
            };

            await Generate(excludedResourceDefinitions, outputDirectoryPath, rootSchemaUriList);
        }

        static async Task Generate(List<string> excludedResourceDefinitions, string outputDirectoryPath, List<string> rootSchemaUriList)
        {
            var allSchemas = new List<JsonSchema>();
            var allDefs = new List<JsonSchema>();
            var allResourceDefs = new List<JsonSchema>();

            foreach (var rootSchemaUri in rootSchemaUriList)
            {
                var rootSchemaFileName = rootSchemaUri.Split("/").Last().Replace("#", "");
                var rootSchemaFilePath = Path.Combine(outputDirectoryPath, rootSchemaFileName);

                // download the ARM schema files listed in the 'rootSchemaUri' and write it to 'outputDirectoryPath'
                await Helper.DownloadSchema(rootSchemaUri, rootSchemaFilePath);
                using var rootSchemaFileStream = File.OpenRead(rootSchemaFilePath);
                using StreamReader sr = new StreamReader(rootSchemaFileStream);
                string schemaText = sr.ReadToEnd();

                // read the root schema and download each Resource Provider's schema
                var schema = SchemaReader.ReadSchema(schemaText, rootSchemaFilePath);
                allSchemas.Add(schema);
            }

            // list to hold schema file information
            List<Models.resourceProvider> rpList = new List<Models.resourceProvider>();

            if (allSchemas == null)
            {
                Console.WriteLine("Root JSON Schema is empty... exiting");
                return;
            }

            // iterate through the 'deploymentTemplate.json' fies
            // create a new object to hold each file's metadata
            // group the files by Resource Provider name & sort descending on the 'apiVersion' field
            foreach (JsonSchema rootSchema in allSchemas)
            {
                foreach (var schema in rootSchema.Definitions)
                {
                    if (schema.Key == "resource")
                    {
                        foreach (var property in schema.Value.OneOf.ElementAt(0).AllOf.ElementAt(1).OneOf.Select(r => r.Reference))
                        {
                            Models.resourceProvider rp = new Models.resourceProvider();
                            rp.VersionDate = DateTime.Parse(property.Uri.Segments.ElementAt(2)
                                .Replace("/", "")
                                .Replace("-preview", "")
                                .Replace("-privatepreview", ""));

                            rp.Name = property.Uri.Segments.ElementAt(3).Replace(".json", "");
                            rp.Version = property.Uri.Segments.ElementAt(2).Replace("/", "");

                            rpList.Add(rp);
                        }
                    }
                }
            }

            // select the most recent schema for each resource provider
            var groupedList = rpList.OrderByDescending(s => s.VersionDate).GroupBy(r => r.Name).ToList();

            // generate a C# class for each schema file /resource provider (RP)
            // each resource provider's classes are collected in a single .cs file named after the RP 
            foreach (var group in groupedList)
            {
                // ensure we are not processing excluded schemas
                if (excludedResourceDefinitions.Contains(group.Key))
                {
                    continue;
                }

                // build uris & file paths
                var schemaUri = "https://schema.management.azure.com/schemas/" + group.First().Version + "/" + group.Key + ".json";
                var namespaceName = group.Key;
                var schemaFileName = namespaceName + ".json";
                var classFileName = namespaceName + ".cs";
                var schemaFilePath = Path.Combine(outputDirectoryPath, schemaFileName);
                var classFilePath = Path.Combine(outputDirectoryPath, classFileName);

                if (File.Exists(classFilePath))
                {
                    Console.WriteLine("Class file '" + classFilePath + "' already exists");
                    continue;
                }

                if (File.Exists(schemaFilePath))
                {
                    Console.WriteLine("Schema file '" + schemaFilePath + "' already exists");
                    continue;
                }

                await Helper.DownloadSchema(schemaUri, schemaFilePath);
                using var fileStream = File.OpenRead(schemaFilePath);
                using StreamReader sr = new StreamReader(fileStream);

                string jsonSchemaText = sr.ReadToEnd();
                var jsonSchema = SchemaReader.ReadSchema(jsonSchemaText, schemaFilePath);
                var outputDirectory = Directory.CreateDirectory(outputDirectoryPath);
                using var streamWriter = new StreamWriter(Path.Combine(outputDirectory.FullName, classFilePath), false);

                // create namespace object to hold generated classes
                var ns = NamespaceDeclaration(ParseName(namespaceName));

                // generate class definition
                var nsCode = Helper.FromSchema(jsonSchema, ns);

                if (nsCode != null)
                {
                    // write generated namespace & classes to a .cs file named after the resource provider
                    Console.WriteLine("Writing class file: " + "'" + classFilePath + "'");
                    nsCode.NormalizeWhitespace().WriteTo(streamWriter);
                }
                else
                {
                    Console.WriteLine("Error parsing schema for resource provider: " + namespaceName);
                }
            }
        }

    }
}