using Bicep.Core.FileSystem;
using Bicep.Core.Registry;
using Bicep.Decompiler;
using System.Collections.Immutable;
using System.IO.Abstractions;

namespace AzureDesignStudio.Services;

public interface IAdsBicepDecompiler
{
    Task<DecompileResult> Decompile(string jsonContent);
}

public record DecompileResult(string? BicepFile, string? Error);

public class EmptyModuleRegistryProvider : IModuleRegistryProvider
{
    public ImmutableArray<IModuleRegistry> Registries(Uri _) => ImmutableArray<IModuleRegistry>.Empty;
}

public class AdsBicepDecompiler : IAdsBicepDecompiler
{
    private readonly IFileSystem _fileSystem;
    private readonly BicepDecompiler _decompiler;

    public AdsBicepDecompiler(IFileSystem fileSystem, BicepDecompiler decompiler)
    {
        _fileSystem = fileSystem;
        _decompiler = decompiler;
    }

    public async Task<DecompileResult> Decompile(string jsonContent)
    {
        var jsonUri = new Uri("file:///main.json");
        await _fileSystem.File.WriteAllTextAsync(jsonUri.LocalPath, jsonContent);

        try
        {
            var bicepUri = PathHelper.ChangeToBicepExtension(jsonUri);
            var (entrypointUri, filesToSave) = await _decompiler.Decompile(jsonUri, bicepUri);

            return new DecompileResult(filesToSave[entrypointUri], null);
        }
        catch (Exception exception)
        {
            return new DecompileResult(null, exception.Message);
        }
    }
}
