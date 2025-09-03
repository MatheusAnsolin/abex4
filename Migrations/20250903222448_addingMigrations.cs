using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SiteBrecho.Migrations
{
    /// <inheritdoc />
    public partial class addingMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administradores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    SenhaHash = table.Column<string>(type: "text", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administradores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fornecedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    CnpjCpf = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Telefone = table.Column<string>(type: "text", nullable: false),
                    Endereco = table.Column<string>(type: "text", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    PrecoCusto = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    PrecoVenda = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    FornecedorId = table.Column<int>(type: "integer", nullable: true),
                    CriadoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AtualizadoEm = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FornecedorModelId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_Fornecedores_FornecedorModelId",
                        column: x => x.FornecedorModelId,
                        principalTable: "Fornecedores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Estoques",
                columns: table => new
                {
                    ProdutoId = table.Column<int>(type: "integer", nullable: false),
                    QuantidadeAtual = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estoques", x => x.ProdutoId);
                    table.ForeignKey(
                        name: "FK_Estoques_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movimentacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProdutoId = table.Column<int>(type: "integer", nullable: false),
                    Tipo = table.Column<string>(type: "text", nullable: false),
                    Quantidade = table.Column<int>(type: "integer", nullable: false),
                    ValorUnitario = table.Column<decimal>(type: "numeric", nullable: false),
                    Data = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AdministradorId = table.Column<int>(type: "integer", nullable: false),
                    ClienteId = table.Column<int>(type: "integer", nullable: true),
                    Observacao = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimentacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movimentacoes_Administradores_AdministradorId",
                        column: x => x.AdministradorId,
                        principalTable: "Administradores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movimentacoes_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Administradores",
                columns: new[] { "Id", "CriadoEm", "Email", "Nome", "SenhaHash" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@admin.com", "Admin", "123456" });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "AtualizadoEm", "CriadoEm", "Descricao", "FornecedorId", "FornecedorModelId", "Nome", "PrecoCusto", "PrecoVenda" },
                values: new object[,]
                {
                    { -4, new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), "Bolsa de ombro em couro legítimo, com detalhes em metal dourado.", 2, null, "Bolsa de Couro Caramelo", 50.00m, 130.00m },
                    { -3, new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), null, 1, null, "Vestido Floral Longo", 35.50m, 95.00m },
                    { -2, new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), "Calça jeans de cintura alta, lavagem clara. Perfeita para um look retrô.", 1, null, "Calça Jeans Reta Anos 90", 25.00m, 79.90m },
                    { -1, new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), new DateTime(2025, 9, 2, 20, 0, 0, 0, DateTimeKind.Utc), "Jaqueta de couro preta, estilo motociclista. Em ótimo estado.", null, null, "Jaqueta de Couro Vintage", 70.00m, 180.50m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacoes_AdministradorId",
                table: "Movimentacoes",
                column: "AdministradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacoes_ProdutoId",
                table: "Movimentacoes",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_FornecedorModelId",
                table: "Produtos",
                column: "FornecedorModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estoques");

            migrationBuilder.DropTable(
                name: "Movimentacoes");

            migrationBuilder.DropTable(
                name: "Administradores");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Fornecedores");
        }
    }
}
