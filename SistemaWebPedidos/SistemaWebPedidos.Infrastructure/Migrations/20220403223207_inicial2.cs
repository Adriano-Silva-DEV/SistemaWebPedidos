using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaWebPedidos.Infrastructure.Migrations
{
    public partial class inicial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUTOS_C_CategoriaId",
                table: "PRODUTOS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_C",
                table: "C");

            migrationBuilder.RenameTable(
                name: "C",
                newName: "CATEGORIAS");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CATEGORIAS",
                table: "CATEGORIAS",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUTOS_CATEGORIAS_CategoriaId",
                table: "PRODUTOS",
                column: "CategoriaId",
                principalTable: "CATEGORIAS",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PRODUTOS_CATEGORIAS_CategoriaId",
                table: "PRODUTOS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CATEGORIAS",
                table: "CATEGORIAS");

            migrationBuilder.RenameTable(
                name: "CATEGORIAS",
                newName: "C");

            migrationBuilder.AddPrimaryKey(
                name: "PK_C",
                table: "C",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PRODUTOS_C_CategoriaId",
                table: "PRODUTOS",
                column: "CategoriaId",
                principalTable: "C",
                principalColumn: "Id");
        }
    }
}
