# SiteBrecho
Projeto ASP.NET Core 8 com MongoDB e Docker.

## Pré-requisitos
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Docker](https://www.docker.com/)
- (Opcional) [Rider](https://www.jetbrains.com/rider/) ou outra IDE C#

## Tecnologias
- .NET 8
- MongoDB
- Docker
- Swashbuckle (Swagger) 

### Dependências NuGet principais

- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Design
- Npgsql.EntityFrameworkCore.PostgreSQL
- Swashbuckle.AspNetCore

## Clonando o repositório
```bash
git clone git@github.com:MatheusAnsolin/abex4.git
cd abex4

## Rodando localmente
1. Restaurar pacotes:
```
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