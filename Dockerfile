FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base

COPY . .


# Install all dependencies
RUN dotnet restore "FM_Rozetka_Api.Api/FM_Rozetka_Api.Api.csproj"

# Install the dotnet-ef tools
RUN dotnet tool install -g dotnet-ef --version 8.0
ENV PATH $PATH:/root/.dotnet/tools

# RUN dotnet-ef database update --startup-project "FM_Rozetka_Api.Api" --project "FM_Rozetka_Api.Infrastructure/FM_Rozetka_Api.Infrastructure.csproj"

RUN dotnet publish "FM_Rozetka_Api.Api/FM_Rozetka_Api.Api.csproj" -c Release -o /app/build
WORKDIR /app/build
EXPOSE 80

ENTRYPOINT ["dotnet", "FM_Rozetka_Api.Api.dll", "--urls=http://0.0.0.0:80"]
