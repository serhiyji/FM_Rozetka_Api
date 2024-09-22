# Learn about building .NET container images:
# https://github.com/dotnet/dotnet-docker/blob/main/samples/README.md
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY ["FM_Rozetka_Api.Api/FM_Rozetka_Api.Api.csproj", "FM_Rozetka_Api.Api/"]
COPY ["FM_Rozetka_Api.Core/FM_Rozetka_Api.Core.csproj", "FM_Rozetka_Api.Core/"]
COPY ["FM_Rozetka_Api.Infrastructure/FM_Rozetka_Api.Infrastructure.csproj", "FM_Rozetka_Api.Infrastructure/"]
RUN dotnet restore "FM_Rozetka_Api.Api/FM_Rozetka_Api.Api.csproj"

# copy everything else and build app
COPY . .
WORKDIR /source/FM_Rozetka_Api.Api
RUN dotnet publish -c Release -o /app


# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "FM_Rozetka_Api.Api.dll"]
