# Build locally: `docker build -f ./Dockerfile -t azuredesignstudioserver --force-rm ..`

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /AzureDesignStudio
COPY . .

WORKDIR "/AzureDesignStudio/src"
RUN dotnet restore "AzureDesignStudio.Server/AzureDesignStudio.Server.csproj"

FROM build AS publish
WORKDIR "/AzureDesignStudio/src/AzureDesignStudio.Server"
RUN dotnet publish "AzureDesignStudio.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AzureDesignStudio.Server.dll"]