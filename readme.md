# 🛍️ SiteBrecho - ERP para Brechó

Este é um projeto de ERP simples voltado para gerenciamento de estoque, produtos, fornecedores e movimentações (venda, compra e devoluções) de um brechó. Criado com foco em MVP, utilizando **ASP.NET Core**, **Entity Framework Core**, **PostgreSQL** e **Docker**.

---

## 🚀 Tecnologias

- [.NET 8](https://dotnet.microsoft.com/)
- [PostgreSQL 16](https://www.postgresql.org/)
- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/)
- [Docker + Docker Compose](https://www.docker.com/)
- [EF Core Tools CLI](https://learn.microsoft.com/en-us/ef/core/cli/)

---

## 🧱 Estrutura de Projeto
```
├── Controllers 
├── Data/
│ ├── AppDbContext.cs 
│ └── AppDbContextFactory.cs
├── Dtos/ 
├── Models/ 
├── Migrations/ 
├── Repositories/ 
├── docker-compose.yml
├── appsettings.json 
└── SiteBrecho.csproj
```

---

## ⚙️ Requisitos

- [.NET SDK 8+](https://dotnet.microsoft.com/download)
- [Docker](https://www.docker.com/get-started)
- [EF Core CLI](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)

Instale as ferramentas EF Core se ainda não tiver:

```
dotnet tool install --global dotnet-ef
```

🐳 Subindo o banco de dados com Docker
```
docker-compose up -d
```
🔧 Configuração do Banco

O banco está configurado em appsettings.json:
```
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=brecho_db;Username=brecho_user;Password=brecho_pass"
}
```

🛠️ Migrations e Banco de Dados
Criar migration
```
dotnet ef migrations add NomeDaMigration
```
Remover última migration (se necessário)
```
dotnet ef migrations remove
```
Aplicar migrations no banco
```
dotnet ef database update
```
🧪 Executar o Projeto
```
dotnet run
```
A API será iniciada em:

http://localhost:5000

👤 Usuário Seed (Admin)

Já existe um administrador pré-cadastrado via HasData() no AppDbContext:
```json
{
  "email": "admin@admin.com",
  "senha": "123456"
}
```
