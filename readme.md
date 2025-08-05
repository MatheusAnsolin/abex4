# SiteBrecho

Projeto ASP.NET Core 8 com MongoDB e Docker.

## Tecnologias

- .NET 8
- MongoDB
- Docker
- Swashbuckle (Swagger)

## Rodando localmente
1. Restaurar pacotes:
dotnet restore
2. Rodar aplicação:
dotnet run

## Rodando com Docker
1. Build da imagem:
docker build -t sitebrecho .
2. Rodar container:
docker run -p 5000:80 sitebrecho

3. Acessar no navegador:
http://localhost:5000