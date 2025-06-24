# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This Dockerfile is used to build the DevIO.Produtos.WebApi service for development and production environments.

# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["DevIO.Produtos.WebApi/DevIO.Produtos.WebApi.csproj", "DevIO.Produtos.WebApi/"]
RUN dotnet restore "DevIO.Produtos.WebApi/DevIO.Produtos.WebApi.csproj"
COPY . .
WORKDIR "/src/DevIO.Produtos.WebApi"
RUN dotnet publish "DevIO.Produtos.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Etapa final (runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
EXPOSE 8081
ENTRYPOINT ["dotnet", "DevIO.Produtos.WebApi.dll"]

# Command to build and run the Docker Compose setup
# docker compose -f Docker/docker-compose.yml up --build