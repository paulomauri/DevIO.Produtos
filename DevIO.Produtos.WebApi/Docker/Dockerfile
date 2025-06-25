# Etapa de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia os .csproj
COPY ["DevIO.Produtos.WebApi/DevIO.Produtos.WebApi.csproj", "DevIO.Produtos.WebApi/"]
COPY ["DevIO.Produtos.Domain/DevIO.Produtos.Domain.csproj", "DevIO.Produtos.Domain/"]
COPY ["DevIO.Produtos.Infrastructure/DevIO.Produtos.Infrastructure.csproj", "DevIO.Produtos.Infrastructure/"]
COPY ["Application/DevIO.Produtos.Application.csproj", "Application/"]

# Restaura dependências
RUN dotnet restore "DevIO.Produtos.WebApi/DevIO.Produtos.WebApi.csproj"

# Copia o código-fonte
COPY . .

# Publica o projeto WebAPI
WORKDIR /src/DevIO.Produtos.WebApi
RUN dotnet publish "DevIO.Produtos.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Etapa final (runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copia os artefatos publicados
COPY --from=build /app/publish .

# Expondo apenas a porta realmente usada (80)
EXPOSE 80

# Ponto de entrada da aplicação
ENTRYPOINT ["dotnet", "DevIO.Produtos.WebApi.dll"]


# rodar o comando abaixo (na raiz da solution) para criar a imagem Docker e iniciar o container
# docker compose -f DevIO.Produtos.WebApi/Docker/docker-compose.yml up --build
