#!/usr/bin/env pwsh

if (!(Test-Path "version.json")) {
  Write-Warning "NerdBank.GitVersioning isn't presented. Check that version.json exists";
  exit -1;
}

if (!(Test-Path "nbgv-version.json")) {
  Write-Warning "nbgv-version.json isn't presented. Run nbgv to generate it.";
  exit -1;
}

$versionOracle = Get-Content .\nbgv-version.json -Raw | ConvertFrom-Json

# so now we can create target file with override

$text = @"
<Project>
<Target Name="GetBuildVersion">
  <PropertyGroup>
    <BuildVersion Condition="'`$(BuildVersion)' == ''">$($versionOracle.Version.ToString())</BuildVersion>
    <AssemblyInformationalVersion Condition="'`$(AssemblyInformationalVersion)' == ''">$($versionOracle.AssemblyInformationalVersion.ToString())</AssemblyInformationalVersion>
    <AssemblyFileVersion Condition="'`$(AssemblyFileVersion)' == ''">$($versionOracle.AssemblyFileVersion.ToString())</AssemblyFileVersion>
    <FileVersion Condition="'`$(FileVersion)' == ''">$($versionOracle.AssemblyFileVersion.ToString())</FileVersion>
    <BuildVersionSimple Condition="'`$(BuildVersionSimple)' == ''">$($versionOracle.SimpleVersion.ToString())</BuildVersionSimple>
    <PrereleaseVersion Condition="'`$(PrereleaseVersion)' == ''">$($versionOracle.PrereleaseVersion.ToString())</PrereleaseVersion>
    <MajorMinorVersion Condition="'`$(MajorMinorVersion)' == ''">$($versionOracle.MajorMinorVersion.ToString())</MajorMinorVersion>
    <AssemblyVersion Condition="'`$(AssemblyVersion)' == ''">$($versionOracle.AssemblyVersion.ToString())</AssemblyVersion>
    <GitCommitId Condition="'`$(GitCommitId)' == ''">$($versionOracle.GitCommitId.ToString())</GitCommitId>
    <GitCommitIdShort Condition="'`$(GitCommitIdShort)' == ''">$($versionOracle.GitCommitIdShort.ToString())</GitCommitIdShort>
    <GitCommitDateTicks Condition="'`$(GitCommitDateTicks)' == ''">$($gitCommitDateTicks)</GitCommitDateTicks>
    <GitVersionHeight Condition="'`$(GitVersionHeight)' == ''">$($versionOracle.VersionHeight)</GitVersionHeight>
    <BuildNumber Condition="'`$(BuildNumber)' == ''">$($versionOracle.BuildNumber.ToString())</BuildNumber>
    <BuildVersionNumberComponent Condition="'`$(BuildVersionNumberComponent)' == ''">$($versionOracle.BuildNumber.ToString())</BuildVersionNumberComponent>
    <PublicRelease Condition="'`$(PublicRelease)' == ''">$($versionOracle.PublicRelease.ToString())</PublicRelease>
    <CloudBuildNumber Condition="'`$(CloudBuildNumber)' == ''">$($versionOracle.CloudBuildNumber.ToString())</CloudBuildNumber>
    <SemVerBuildSuffix Condition="'`$(SemVerBuildSuffix)' == ''">$($versionOracle.BuildMetadataFragment.ToString())</SemVerBuildSuffix>
    <NuGetPackageVersion Condition="'`$(NuGetPackageVersion)' == ''">$($versionOracle.NuGetPackageVersion.ToString())</NuGetPackageVersion>
    <ChocolateyPackageVersion Condition="'`$(ChocolateyPackageVersion)' == ''">$($versionOracle.ChocolateyPackageVersion.ToString())</ChocolateyPackageVersion>
    <Version Condition="'`$(Version)' == ''">$($versionOracle.NuGetPackageVersion.ToString())</Version>
    <PackageVersion Condition="'`$(PackageVersion)' == ''">$($versionOracle.NuGetPackageVersion.ToString())</PackageVersion>
    <NPMPackageVersion Condition="'`$(NPMPackageVersion)' == ''">$($versionOracle.NPMPackageVersion.ToString())</NPMPackageVersion>
  </PropertyGroup>
</Target>
</Project>
"@
$text | Out-File .\Directory.Build.targets

Write-Host "Directory.Build.target has been generated. Nerdbank Version: $($versionOracle.NuGetPackageVersion.ToString())";