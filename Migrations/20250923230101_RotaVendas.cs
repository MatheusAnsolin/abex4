using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SiteBrecho.Migrations
{
    /// <inheritdoc />
    public partial class RotaVendas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Fornecedores_FornecedorModelId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_FornecedorModelId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "FornecedorModelId",
                table: "Produtos");

            migrationBuilder.AlterColumn<string>(
                name: "Observacao",
                table: "Movimentacoes",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DataVenda = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NomeCliente = table.Column<string>(type: "text", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "numeric(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VendaItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    VendaId = table.Column<int>(type: "integer", nullable: true),
                    ProdutoId = table.Column<int>(type: "integer", nullable: false),
                    Quantidade = table.Column<int>(type: "integer", nullable: false),
                    PrecoUnitario = table.Column<decimal>(type: "numeric(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendaItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VendaItems_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VendaItems_Vendas_VendaId",
                        column: x => x.VendaId,
                        principalTable: "Vendas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_VendaItems_ProdutoId",
                table: "VendaItems",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_VendaItems_VendaId",
                table: "VendaItems",
                column: "VendaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VendaItems");

            migrationBuilder.DropTable(
                name: "Vendas");

            migrationBuilder.AddColumn<int>(
                name: "FornecedorModelId",
                table: "Produtos",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Observacao",
                table: "Movimentacoes",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: -4,
                column: "FornecedorModelId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: -3,
                column: "FornecedorModelId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: -2,
                column: "FornecedorModelId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: -1,
                column: "FornecedorModelId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_FornecedorModelId",
                table: "Produtos",
                column: "FornecedorModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Fornecedores_FornecedorModelId",
                table: "Produtos",
                column: "FornecedorModelId",
                principalTable: "Fornecedores",
                principalColumn: "Id");
        }
    }
}
