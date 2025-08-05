# imagem base para rodar a aplicação ASP.NET Core
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# imagem para build da aplicação com SDK completo
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# copia todos os arquivos do projeto para dentro do container
COPY . .

# restaura os pacotes NuGet necessários
RUN dotnet restore

# publica o projeto em modo Release na pasta /app/publish
RUN dotnet publish -c Release -o /app/publish

# imagem final que roda o app
FROM base AS final
WORKDIR /app

# copia os arquivos publicados da etapa build para o container final
COPY --from=build /app/publish .

# define o comando padrão ao iniciar o container
ENTRYPOINT ["dotnet", "SiteBrecho.dll"]
