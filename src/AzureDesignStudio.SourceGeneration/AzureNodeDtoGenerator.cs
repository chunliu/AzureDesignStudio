using AzureDesignStudio.SourceGeneration.Models;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Scriban;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AzureDesignStudio.SourceGeneration
{
    public static class GeneratorConsts
    {
        public const string DtoAttributeName = "MapToDto";
    }

    [Generator]
    public class AzureNodeDtoGenerator : ISourceGenerator
    {
        public void Initialize(GeneratorInitializationContext context)
        {
            // Uncomment if debugging.
            //if (!Debugger.IsAttached)
            //{
            //    Debugger.Launch();
            //}

            context.RegisterForSyntaxNotifications(() => new DtoGeneratorSyntaxReceiver());
        } 
        
        public void Execute(GeneratorExecutionContext context)
        {

            if (context.SyntaxReceiver is not DtoGeneratorSyntaxReceiver dtoReceiver)
                return;

            if (string.IsNullOrEmpty(dtoReceiver.DtoNamespace))
            {
                throw new ArgumentNullException(nameof(dtoReceiver.DtoNamespace));
            }

            var mapProfile = new MapProfileModel()
            {
                Maps = new List<MapModel>(),
                Usings = new HashSet<string>
                {
                    dtoReceiver.TypeKeyNamespace!,
                },
                Namespace = dtoReceiver.MapProfileNamespace!
            };

            foreach (var model in dtoReceiver.ModelTypes)
            {
                var dtoTypeModel = CreateDtoTypeModel(model, dtoReceiver.DtoNamespace!);
                var source = GenerateSourceFromDtoTypeModel(dtoTypeModel);

                context.AddSource($"{dtoTypeModel.ClassName}.g.cs", source);

                var typeKey = model.GetAttributeParameterValue(GeneratorConsts.DtoAttributeName, "TypeKey");
                mapProfile.Maps.Add(new MapModel
                {
                    TypeKey = (string.IsNullOrEmpty(typeKey) ? string.Empty : typeKey)!,
                    SourceType = model.Identifier.Text,
                    DestinationType = dtoTypeModel.ClassName
                });
                mapProfile.Usings.Add(dtoTypeModel.Namespace);
            }

            var mpSource = GenerateSourceFromMapProfileModel(mapProfile);
            context.AddSource($"AzureNodeProfile.g.cs", mpSource);

            var dmfSource = GenerateSourceForDataModelFactory(mapProfile);
            context.AddSource($"DataModelFactory.g.cs", dmfSource);
        }

        private static DtoTypeModel CreateDtoTypeModel(ClassDeclarationSyntax classDecl, string dtoNamespace)
        {
            var model = new DtoTypeModel()
            {
                ClassName = $"{classDecl.Identifier.Text}Dto",
                Namespace = classDecl.GetNamespace(),
                DtoBase = classDecl.GetAttributeParameterValue(GeneratorConsts.DtoAttributeName, "DtoBase") ?? "AzureNodeDto",
                Usings = new List<string>
                {
                    "System.Collections.Generic",
                    dtoNamespace
                },
                Properties = new List<DtoTypeProperty>(),
            };

            foreach(var member in classDecl.Members)
            {
                if (member is PropertyDeclarationSyntax propSyntax && propSyntax.HasAttribute(GeneratorConsts.DtoAttributeName))
                {
                    var propType = propSyntax.GetAttributeParameterValue(GeneratorConsts.DtoAttributeName, "DtoPropertyType");
                    model.Properties.Add(new DtoTypeProperty()
                    {
                        Type = (string.IsNullOrEmpty(propType) ? propSyntax.Type.GetText().ToString() : propType)!,
                        Identifier = propSyntax.Identifier.Text,
                    });
                }
            }

            return model;
        }

        private static string GenerateSourceFromDtoTypeModel(DtoTypeModel model)
        {
            var templateStr = ResourceReader.GetResource("AzureNodeDto.scriban");
            return GenerateSourceFromModel(templateStr!, model);
        }

        private static string GenerateSourceFromMapProfileModel(MapProfileModel model)
        {
            var templateStr = ResourceReader.GetResource("AzureNodeProfile.scriban");
            return GenerateSourceFromModel(templateStr!, model);
        }

        private static string GenerateSourceForDataModelFactory(MapProfileModel model)
        {
            var templateStr = ResourceReader.GetResource("DataModelFactory.scriban");
            return GenerateSourceFromModel(templateStr!, model);
        }

        private static string GenerateSourceFromModel(string templateString, object model)
        {
            var template = Template.Parse(templateString);
            if (template.HasErrors)
            {
                var errors = string.Join(" | ", template.Messages.Select(x => x.Message));
                throw new InvalidOperationException($"Template parse error: {template.Messages}");
            }

            var source = template.Render(model, memberRenamer: member => member.Name);

            return SyntaxFactory.ParseCompilationUnit(source)
                                  .NormalizeWhitespace()
                                  .GetText()
                                  .ToString();
        }
    }
}
