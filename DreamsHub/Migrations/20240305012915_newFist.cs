using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DreamsHub.Migrations
{
    /// <inheritdoc />
    public partial class newFist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Orcamentos_CategoriaId",
                table: "Clientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orcamentos",
                table: "Orcamentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes");

            migrationBuilder.RenameTable(
                name: "Orcamentos",
                newName: "Categorias");

            migrationBuilder.RenameTable(
                name: "Clientes",
                newName: "Transacoes");

            migrationBuilder.RenameIndex(
                name: "IX_Clientes_CategoriaId",
                table: "Transacoes",
                newName: "IX_Transacoes_CategoriaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categorias",
                table: "Categorias",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Transacoes",
                table: "Transacoes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transacoes_Categorias_CategoriaId",
                table: "Transacoes",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transacoes_Categorias_CategoriaId",
                table: "Transacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Transacoes",
                table: "Transacoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categorias",
                table: "Categorias");

            migrationBuilder.RenameTable(
                name: "Transacoes",
                newName: "Clientes");

            migrationBuilder.RenameTable(
                name: "Categorias",
                newName: "Orcamentos");

            migrationBuilder.RenameIndex(
                name: "IX_Transacoes_CategoriaId",
                table: "Clientes",
                newName: "IX_Clientes_CategoriaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orcamentos",
                table: "Orcamentos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Orcamentos_CategoriaId",
                table: "Clientes",
                column: "CategoriaId",
                principalTable: "Orcamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
