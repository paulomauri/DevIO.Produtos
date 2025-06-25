# Etapa de build
# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["DevIO.Produtos.WebApi/DevIO.Produtos.WebApi.csproj", "DevIO.Produtos.WebApi/"]
COPY ["DevIO.Produtos.Domain/DevIO.Produtos.Domain.csproj", "DevIO.Produtos.Domain/"]
COPY ["DevIO.Produtos.Infrastructure/DevIO.Produtos.Infrastructure.csproj", "DevIO.Produtos.Infrastructure/"]
COPY ["Application/DevIO.Produtos.Application.csproj", "Application/"]
RUN dotnet restore "DevIO.Produtos.WebApi/DevIO.Produtos.WebApi.csproj"

COPY DevIO.Produtos.WebApi/*.cs* ./DevIO.Produtos.WebApi/
COPY DevIO.Produtos.WebApi/Controllers ./DevIO.Produtos.WebApi/Controllers
COPY DevIO.Produtos.WebApi/Properties ./DevIO.Produtos.WebApi/Properties
COPY DevIO.Produtos.WebApi/appsettings*.json ./DevIO.Produtos.WebApi/
COPY DevIO.Produtos.WebApi/DevIO.Produtos.WebApi.http ./DevIO.Produtos.WebApi/

COPY DevIO.Produtos.Domain/. ./DevIO.Produtos.Domain/
COPY DevIO.Produtos.Infrastructure/. ./DevIO.Produtos.Infrastructure/
COPY Application/. ./Application/
WORKDIR /src/DevIO.Produtos.WebApi
RUN dotnet publish "DevIO.Produtos.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Etapa final (runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
EXPOSE 8081
ENTRYPOINT ["dotnet", "DevIO.Produtos.WebApi.dll"]

# rodar o comando abaixo (na raiz da solution) para criar a imagem Docker e iniciar o container
# docker compose -f DevIO.Produtos.WebApi/Docker/docker-compose.yml up --build
