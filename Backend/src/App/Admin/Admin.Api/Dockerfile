# Use ASP.NET 8.0 as the base image, and create an alias for base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 60020
EXPOSE 60022

# Use .NET SDK 8.0 for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy project files
COPY ["Directory.Build.props", "."]

# Copy Admin projects
COPY ["App/Admin/Admin.Api/Dkd.App.Admin.Api.csproj", "App/Admin/Admin.Api/"]
COPY ["App/Admin/Admin.Application/Dkd.App.Admin.Application.csproj", "App/Admin/Admin.Application/"]
COPY ["App/Admin/Admin.Repository/Dkd.App.Admin.Repository.csproj", "App/Admin/Admin.Repository/"]
COPY ["App/Admin/Admin.Application.Contracts/Dkd.App.Admin.Application.Contracts.csproj", "App/Admin/Admin.Application.Contracts/"]

# Copy Shared projects
COPY ["App/Shared/Remote.Http/Dkd.App.Remote.Http.csproj", "App/Shared/Remote.Http/"]
COPY ["App/Shared/Remote.Grpc/Dkd.App.Remote.Grpc.csproj", "App/Shared/Remote.Grpc/"]
COPY ["App/Shared/Const/Dkd.App.Const.csproj", "App/Shared/Const/"]
COPY ["App/Shared/Remote.Event/Dkd.App.Remote.Event.csproj", "App/Shared/Remote.Event/"]

# Copy Infrastructure projects
COPY ["Infrastructures/Helper/Dkd.Infra.Helper.csproj", "Infrastructures/Helper/"]
COPY ["Infrastructures/Core/Dkd.Infra.Core.csproj", "Infrastructures/Core/"]
COPY ["Infrastructures/Redis.Caching/Dkd.Infra.Redis.Caching.csproj", "Infrastructures/Redis.Caching/"]
COPY ["Infrastructures/Redis/Dkd.Infra.Redis.csproj", "Infrastructures/Redis/"]
COPY ["Infrastructures/Repository/Dkd.Infra.Repository.csproj", "Infrastructures/Repository/"]
COPY ["Infrastructures/Repository.EfCore.Mysql/Dkd.Infra.Repository.EfCore.MySql.csproj", "Infrastructures/Repository.EfCore.Mysql/"]
COPY ["Infrastructures/Repository.EfCore/Dkd.Infra.Repository.EfCore.csproj", "Infrastructures/Repository.EfCore/"]
COPY ["Infrastructures/Consul/Dkd.Infra.Consul.csproj", "Infrastructures/Consul/"]
COPY ["Infrastructures/Repository.Dapper/Dkd.Infra.Repository.Dapper.csproj", "Infrastructures/Repository.Dapper/"]
COPY ["Infrastructures/EventBus/Dkd.Infra.EventBus.csproj", "Infrastructures/EventBus/"]
COPY ["Infrastructures/IdGenerater/Dkd.Infra.IdGenerater.csproj", "Infrastructures/IdGenerater/"]
COPY ["Infrastructures/Repository.EfCore.MongoDB/Dkd.Infra.Repository.EfCore.MongoDB.csproj", "Infrastructures/Repository.EfCore.MongoDB/"]

# Copy Service Shared projects
COPY ["ServiceShared/Shared/Dkd.Shared.csproj", "ServiceShared/Shared/"]
COPY ["ServiceShared/Application.Contracts/Dkd.Shared.Application.Contracts.csproj", "ServiceShared/Application.Contracts/"]
COPY ["ServiceShared/Remote/Dkd.Shared.Remote.csproj", "ServiceShared/Remote/"]
COPY ["ServiceShared/Repository/Dkd.Shared.Repository.csproj", "ServiceShared/Repository/"]
COPY ["ServiceShared/Application/Dkd.Shared.Application.csproj", "ServiceShared/Application/"]
COPY ["ServiceShared/WebApi/Dkd.Shared.WebApi.csproj", "ServiceShared/WebApi/"]

# Diagnostic step to check the contents of /src
RUN ls -R /src

# Restore dependencies
RUN --mount=type=cache,id=nuget,target=/root/.nuget/packages \
    dotnet restore "./App/Admin/Admin.Api/Dkd.App.Admin.Api.csproj" --disable-parallel

# Copy everything else and build
COPY . .
WORKDIR "/src/App/Admin/Admin.Api"
ARG BUILD_CONFIGURATION=Release
RUN --mount=type=cache,id=nuget,target=/root/.nuget/packages\
    dotnet build "./Dkd.App.Admin.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
RUN --mount=type=cache,id=nuget,target=/root/.nuget/packages\
    dotnet publish "./Dkd.App.Admin.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Dkd.App.Admin.Api.dll"]
