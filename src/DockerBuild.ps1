#!/usr/bin/env pwsh

Write-Host "Get Nerdbank Git Version."

nbgv get-version -f json | Out-File .\nbgv-version.json

.\GenerateVersioningTargets.ps1

docker build -f ./AzureDesignStudio.Server/Dockerfile -t azuredesignstudioserver --force-rm .

Remove-Item -Path .\nbgv-version.json, .\Directory.Build.targets

Write-Host "Build completed."