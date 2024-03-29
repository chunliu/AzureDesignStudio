#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["AzureDesignStudio.Server/AzureDesignStudio.Server.csproj", "AzureDesignStudio.Server/"]
COPY ["AzureDesignStudio.SharedModels/AzureDesignStudio.SharedModels.csproj", "AzureDesignStudio.SharedModels/"]
COPY ["AzureDesignStudio/AzureDesignStudio.csproj", "AzureDesignStudio/"]
COPY ["AzureDesignStudio.Core/AzureDesignStudio.Core.csproj", "AzureDesignStudio.Core/"]
COPY ["AzureDesignStudio.AzureResources/AzureDesignStudio.AzureResources.csproj", "AzureDesignStudio.AzureResources/"]
COPY ["Blazor.Diagrams/src/Blazor.Diagrams.Core/Blazor.Diagrams.Core.csproj", "Blazor.Diagrams/src/Blazor.Diagrams.Core/"]
COPY ["Blazor.Diagrams/src/Blazor.Diagrams/Blazor.Diagrams.csproj", "Blazor.Diagrams/src/Blazor.Diagrams/"]
COPY ["AzureDesignStudio.SourceGeneration/AzureDesignStudio.SourceGeneration.csproj", "AzureDesignStudio.SourceGeneration/"]
RUN dotnet restore "AzureDesignStudio.Server/AzureDesignStudio.Server.csproj"
COPY . .
WORKDIR "/src/AzureDesignStudio.Server"
RUN dotnet build "AzureDesignStudio.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AzureDesignStudio.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AzureDesignStudio.Server.dll"]