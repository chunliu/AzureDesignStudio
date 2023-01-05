using Bicep.Core.Analyzers.Interfaces;
using Bicep.Core.Analyzers.Linter.ApiVersions;
using Bicep.Core.Analyzers.Linter;
using Bicep.Core.Features;
using Bicep.Core.FileSystem;
using Bicep.Core.Registry.Auth;
using Bicep.Core.Registry;
using Bicep.Core.Semantics.Namespaces;
using Bicep.Core.TypeSystem.Az;
using Bicep.Core;
using System.IO.Abstractions.TestingHelpers;
using System.IO.Abstractions;
using Bicep.Core.Configuration;
using ConfigurationManager = Bicep.Core.Configuration.ConfigurationManager;
using Bicep.Decompiler;

namespace AzureDesignStudio.Services;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddAdsBicepDecompiler(this IServiceCollection services) => services
        .AddSingleton<INamespaceProvider, DefaultNamespaceProvider>()
        .AddSingleton<IAzResourceTypeLoader, AzResourceTypeLoader>()
        .AddSingleton<IModuleDispatcher, ModuleDispatcher>()
        .AddSingleton<IModuleRegistryProvider, EmptyModuleRegistryProvider>()
        .AddSingleton<ITokenCredentialFactory, TokenCredentialFactory>()
        .AddSingleton<IFileResolver, FileResolver>()
        .AddSingleton<IFileSystem, MockFileSystem>()
        .AddSingleton<IConfigurationManager, ConfigurationManager>()
        .AddSingleton<IApiVersionProviderFactory, ApiVersionProviderFactory>()
        .AddSingleton<IBicepAnalyzer, LinterAnalyzer>()
        .AddSingleton<IFeatureProviderFactory, FeatureProviderFactory>()
        .AddSingleton<ILinterRulesProvider, LinterRulesProvider>()
        .AddSingleton<BicepCompiler>()
        .AddSingleton<BicepDecompiler>()
        .AddSingleton<IAdsBicepDecompiler, AdsBicepDecompiler>();
}
