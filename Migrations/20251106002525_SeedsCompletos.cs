using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SiteBrecho.Migrations
{
    /// <inheritdoc />
    public partial class SeedsCompletos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.AddColumn<DateTime>(
                name: "AtualizadoEm",
                table: "Fornecedores",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Fornecedores",
                columns: new[] { "Id", "Ativo", "AtualizadoEm", "CnpjCpf", "CriadoEm", "Email", "Endereco", "Excluido", "Nome", "Telefone" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), "12.345.678/0001-90", new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), "contato@brechodavila.com.br", "Rua das Flores, 123 - São Paulo/SP", false, "Brechó da Vila", "(11) 98765-4321" },
                    { 2, true, new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), "98.765.432/0001-10", new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), "vendas@vintagestore.com.br", "Av. Paulista, 456 - São Paulo/SP", false, "Vintage Store", "(11) 91234-5678" }
                });

            migrationBuilder.InsertData(
                table: "ProdutoVariations",
                columns: new[] { "Id", "Ativo", "AtualizadoEm", "CriadoEm", "Descricao", "Excluido", "Nome" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), "Pequeno", false, "Tamanho P" },
                    { 2, true, new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), "Médio", false, "Tamanho M" },
                    { 3, true, new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), "Grande", false, "Tamanho G" },
                    { 4, true, new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), null, false, "Cor Preta" },
                    { 5, true, new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), null, false, "Cor Azul" },
                    { 6, true, new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), null, false, "Cor Vermelha" }
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "Ativo", "AtualizadoEm", "CriadoEm", "Descricao", "Excluido", "FornecedorId", "Nome", "PrecoCusto", "PrecoVenda" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), "Jaqueta de couro estilo motociclista. Em ótimo estado.", false, 1, "Jaqueta de Couro Vintage", 70.00m, 180.50m },
                    { 2, true, new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), "Calça jeans de cintura alta, lavagem clara. Perfeita para um look retrô.", false, 1, "Calça Jeans Reta Anos 90", 25.00m, 79.90m },
                    { 3, true, new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), "Vestido longo com estampa floral, ideal para o verão.", false, 2, "Vestido Floral Longo", 35.50m, 95.00m },
                    { 4, true, new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), "Bolsa de ombro em couro legítimo, com detalhes em metal dourado.", false, 2, "Bolsa de Couro Caramelo", 50.00m, 130.00m }
                });

            migrationBuilder.InsertData(
                table: "Vendas",
                columns: new[] { "Id", "Ativo", "AtualizadoEm", "CriadoEm", "DataVenda", "Excluido", "NomeCliente", "ValorTotal" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), false, "Maria Silva", 275.40m },
                    { 2, true, new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 9, 3, 20, 0, 0, 0, DateTimeKind.Utc), false, "João Santos", 95.00m }
                });

            migrationBuilder.InsertData(
                table: "ProdutoSkus",
                columns: new[] { "Id", "Ativo", "AtualizadoEm", "CriadoEm", "Descricao", "Excluido", "PrecoVenda", "ProdutoId", "ProdutoVariationId1", "ProdutoVariationId2" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), "Jaqueta M Preta", false, 180.50m, 1, 2, 4 },
                    { 2, true, new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), "Jaqueta G Preta", false, 185.00m, 1, 3, 4 },
                    { 3, true, new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), "Calça Jeans P Azul", false, 79.90m, 2, 1, 5 },
                    { 4, true, new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), "Calça Jeans M Azul", false, 79.90m, 2, 2, 5 },
                    { 5, true, new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), "Vestido P Vermelho", false, 95.00m, 3, 1, 6 },
                    { 6, true, new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), "Vestido M Vermelho", false, 95.00m, 3, 2, 6 },
                    { 7, true, new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), "Bolsa Tamanho M", false, 130.00m, 4, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Estoques",
                columns: new[] { "ProdutoSkuId", "Ativo", "AtualizadoEm", "CriadoEm", "Excluido", "QuantidadeAtual" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), false, 5 },
                    { 2, true, new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), false, 3 },
                    { 3, true, new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), false, 8 },
                    { 4, true, new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), false, 10 },
                    { 5, true, new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), false, 4 },
                    { 6, true, new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), false, 6 },
                    { 7, true, new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), false, 2 }
                });

            migrationBuilder.InsertData(
                table: "VendaItems",
                columns: new[] { "Id", "Ativo", "AtualizadoEm", "CriadoEm", "Excluido", "PrecoUnitario", "ProdutoSkuId", "Quantidade", "VendaId" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), false, 180.50m, 1, 1, 1 },
                    { 2, true, new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), false, 79.90m, 3, 1, 1 },
                    { 3, true, new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), false, 95.00m, 5, 1, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Estoques",
                keyColumn: "ProdutoSkuId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Estoques",
                keyColumn: "ProdutoSkuId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Estoques",
                keyColumn: "ProdutoSkuId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Estoques",
                keyColumn: "ProdutoSkuId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Estoques",
                keyColumn: "ProdutoSkuId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Estoques",
                keyColumn: "ProdutoSkuId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Estoques",
                keyColumn: "ProdutoSkuId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Fornecedores",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Fornecedores",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VendaItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VendaItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VendaItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProdutoSkus",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProdutoSkus",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProdutoSkus",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProdutoSkus",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProdutoSkus",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProdutoSkus",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProdutoSkus",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Vendas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vendas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProdutoVariations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProdutoVariations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProdutoVariations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProdutoVariations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProdutoVariations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProdutoVariations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "AtualizadoEm",
                table: "Fornecedores");

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "Ativo", "AtualizadoEm", "CriadoEm", "Descricao", "Excluido", "FornecedorId", "Nome", "PrecoCusto", "PrecoVenda" },
                values: new object[,]
                {
                    { -4, true, new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), "Bolsa de ombro em couro legítimo, com detalhes em metal dourado.", false, 2, "Bolsa de Couro Caramelo", 50.00m, 130.00m },
                    { -3, true, new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), null, false, 1, "Vestido Floral Longo", 35.50m, 95.00m },
                    { -2, true, new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), "Calça jeans de cintura alta, lavagem clara. Perfeita para um look retrô.", false, 1, "Calça Jeans Reta Anos 90", 25.00m, 79.90m },
                    { -1, true, new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), "Jaqueta de couro preta, estilo motociclista. Em ótimo estado.", false, null, "Jaqueta de Couro Vintage", 70.00m, 180.50m }
                });
        }
    }
}
