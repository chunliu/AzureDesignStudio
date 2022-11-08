using Bicep.Core.Analyzers.Linter;
using Bicep.Core.Analyzers.Linter.ApiVersions;
using Bicep.Core.Configuration;
using Bicep.Core.Features;
using Bicep.Core.FileSystem;
using Bicep.Core.Registry;
using Bicep.Core.Semantics.Namespaces;
using Bicep.Core.TypeSystem.Az;
using Bicep.Decompiler;
using System.Collections.Immutable;

namespace AzureDesignStudio.Services
{
    public record DecompileResult(string? BicepFile, string? Error);

    public class EmptyModuleRegistryProvider : IModuleRegistryProvider
    {
        public ImmutableArray<IModuleRegistry> Registries(Uri _) => ImmutableArray<IModuleRegistry>.Empty;
    }

    public class BicepDecompiler
    {
        private static readonly IConfigurationManager configurationManager = IConfigurationManager.WithStaticConfiguration(IConfigurationManager.GetBuiltInConfiguration().WithAllAnalyzersDisabled());

        private static readonly IFeatureProviderFactory featureProviderFactory = new FeatureProviderFactory(configurationManager);

        private static readonly INamespaceProvider namespaceProvider
            = new DefaultNamespaceProvider(new AzResourceTypeLoader());

        private static readonly IApiVersionProviderFactory apiVersionProviderFactory = new ApiVersionProviderFactory(featureProviderFactory, namespaceProvider);

        private static readonly LinterAnalyzer linterAnalyzer = new LinterAnalyzer();

        public static DecompileResult Decompile(string jsonContent)
        {
            var jsonUri = new Uri("inmemory:///main.json");

            var fileResolver = new InMemoryFileResolver(new Dictionary<Uri, string>
            {
                [jsonUri] = jsonContent,
            });

            try
            {
                var bicepUri = PathHelper.ChangeToBicepExtension(jsonUri);
                var decompiler = new TemplateDecompiler(featureProviderFactory, namespaceProvider, fileResolver,
                    new EmptyModuleRegistryProvider(), apiVersionProviderFactory, linterAnalyzer);
                var (entrypointUri, filesToSave) = decompiler.DecompileFileWithModules(jsonUri, bicepUri);

                return new DecompileResult(filesToSave[entrypointUri], null);
            }
            catch (Exception exception)
            {
                return new DecompileResult(null, exception.Message);
            }
        }
    }
}
