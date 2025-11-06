using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SiteBrecho.Migrations
{
    /// <inheritdoc />
    public partial class RefactorProdutoVariationAndEstoque : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estoques_Produtos_ProdutoId",
                table: "Estoques");

            migrationBuilder.DropForeignKey(
                name: "FK_Movimentacoes_Produtos_ProdutoId",
                table: "Movimentacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoSkus_ProdutoVariationModel_ProdutoVariationId1",
                table: "ProdutoSkus");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoSkus_ProdutoVariationModel_ProdutoVariationId2",
                table: "ProdutoSkus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProdutoVariationModel",
                table: "ProdutoVariationModel");

            migrationBuilder.RenameTable(
                name: "ProdutoVariationModel",
                newName: "ProdutoVariations");

            migrationBuilder.RenameColumn(
                name: "ProdutoId",
                table: "Movimentacoes",
                newName: "ProdutoSkuId");

            migrationBuilder.RenameIndex(
                name: "IX_Movimentacoes_ProdutoId",
                table: "Movimentacoes",
                newName: "IX_Movimentacoes_ProdutoSkuId");

            migrationBuilder.RenameColumn(
                name: "ProdutoId",
                table: "Estoques",
                newName: "ProdutoSkuId");

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "ProdutoVariations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Excluido",
                table: "ProdutoVariations",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "ProdutoVariations",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProdutoVariations",
                table: "ProdutoVariations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Estoques_ProdutoSkus_ProdutoSkuId",
                table: "Estoques",
                column: "ProdutoSkuId",
                principalTable: "ProdutoSkus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movimentacoes_ProdutoSkus_ProdutoSkuId",
                table: "Movimentacoes",
                column: "ProdutoSkuId",
                principalTable: "ProdutoSkus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoSkus_ProdutoVariations_ProdutoVariationId1",
                table: "ProdutoSkus",
                column: "ProdutoVariationId1",
                principalTable: "ProdutoVariations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoSkus_ProdutoVariations_ProdutoVariationId2",
                table: "ProdutoSkus",
                column: "ProdutoVariationId2",
                principalTable: "ProdutoVariations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estoques_ProdutoSkus_ProdutoSkuId",
                table: "Estoques");

            migrationBuilder.DropForeignKey(
                name: "FK_Movimentacoes_ProdutoSkus_ProdutoSkuId",
                table: "Movimentacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoSkus_ProdutoVariations_ProdutoVariationId1",
                table: "ProdutoSkus");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoSkus_ProdutoVariations_ProdutoVariationId2",
                table: "ProdutoSkus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProdutoVariations",
                table: "ProdutoVariations");

            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "ProdutoVariations");

            migrationBuilder.DropColumn(
                name: "Excluido",
                table: "ProdutoVariations");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "ProdutoVariations");

            migrationBuilder.RenameTable(
                name: "ProdutoVariations",
                newName: "ProdutoVariationModel");

            migrationBuilder.RenameColumn(
                name: "ProdutoSkuId",
                table: "Movimentacoes",
                newName: "ProdutoId");

            migrationBuilder.RenameIndex(
                name: "IX_Movimentacoes_ProdutoSkuId",
                table: "Movimentacoes",
                newName: "IX_Movimentacoes_ProdutoId");

            migrationBuilder.RenameColumn(
                name: "ProdutoSkuId",
                table: "Estoques",
                newName: "ProdutoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProdutoVariationModel",
                table: "ProdutoVariationModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Estoques_Produtos_ProdutoId",
                table: "Estoques",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movimentacoes_Produtos_ProdutoId",
                table: "Movimentacoes",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoSkus_ProdutoVariationModel_ProdutoVariationId1",
                table: "ProdutoSkus",
                column: "ProdutoVariationId1",
                principalTable: "ProdutoVariationModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoSkus_ProdutoVariationModel_ProdutoVariationId2",
                table: "ProdutoSkus",
                column: "ProdutoVariationId2",
                principalTable: "ProdutoVariationModel",
                principalColumn: "Id");
        }
    }
}
