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
    [Generator]
    public class AzureNodeDtoGenerator : ISourceGenerator
    {
        private readonly DiagnosticDescriptor _errorDescriptor = new("ADS001",
            "ADS001: Error in source generation", "Error in source generator<{0}>: '{1}'", "SourceGenerator",
            DiagnosticSeverity.Error, true);
        private readonly DiagnosticDescriptor _infoDescriptor = new("ADS002",
            "ADS001: Generation working", "Info in source generator<{0}>: '{1}'", "SourceGenerator",
            DiagnosticSeverity.Info, true);
        public void Initialize(GeneratorInitializationContext context)
        {
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
                context.ReportDiagnostic(Diagnostic.Create(_errorDescriptor, Location.None, "Dto namespace not found."));
                return;
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

                var typeKey = GetTypeKeyFromAttribute(model);
                mapProfile.Maps.Add(new MapModel
                {
                    TypeKey = typeKey!,
                    SourceType = model.Identifier.Text,
                    DestinationType = dtoTypeModel.ClassName
                });
                mapProfile.Usings.Add(dtoTypeModel.Namespace);
            }

            var mpSource = GenerateSourceFromMapProfileModel(mapProfile);

            context.AddSource($"AzureNodeProfile.g.cs", mpSource);
        }

        private static string? GetTypeKeyFromAttribute(ClassDeclarationSyntax classDecl)
        {
            var attributeSyntax = classDecl.GetAttribute("MapToDto");
            var expression = attributeSyntax?.ArgumentList?.Arguments
                .Where(a => a.NameEquals?.Name.Identifier.Text == "TypeKey")
                .FirstOrDefault()?
                .ToString();

            return expression?.Split('=').Last();
        }

        private static DtoTypeModel CreateDtoTypeModel(ClassDeclarationSyntax classDecl, string dtoNamespace)
        {
            var model = new DtoTypeModel()
            {
                ClassName = $"{classDecl.Identifier.Text}Dto",
                Namespace = classDecl.GetNamespace(),
                Usings = new List<string>
                {
                    "System.Collections.Generic",
                    dtoNamespace
                },
                Properties = new List<DtoTypeProperty>(),
            };

            foreach(var member in classDecl.Members)
            {
                if (member is PropertyDeclarationSyntax propSyntax && propSyntax.HasAttribute("MapToDto"))
                {
                    model.Properties.Add(new DtoTypeProperty()
                    {
                        Type = propSyntax.Type.GetText().ToString(),
                        Identifier = propSyntax.Identifier.Text,
                    });
                }
            }

            return model;
        }

        private static string GenerateSourceFromDtoTypeModel(DtoTypeModel model)
        {
            var templateStr = ResourceReader.GetResource("AzureNodeDto.scriban");
            var template = Template.Parse(templateStr);
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

        private static string GenerateSourceFromMapProfileModel(MapProfileModel model)
        {
            var templateStr = ResourceReader.GetResource("AzureNodeProfile.scriban");
            var template = Template.Parse(templateStr);
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
