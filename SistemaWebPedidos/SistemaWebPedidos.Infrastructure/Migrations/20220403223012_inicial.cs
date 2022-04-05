using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaWebPedidos.Infrastructure.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "C",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_C", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ENDERECOS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Numero = table.Column<string>(type: "text", nullable: true),
                    Rua = table.Column<string>(type: "varchar(200)", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(50)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(30)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENDERECOS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FORNECEDORES",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    Documento = table.Column<string>(type: "varchar(14)", nullable: false),
                    TipoFornecedor = table.Column<int>(type: "integer", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FORNECEDORES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "USUARIOS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    Telefone = table.Column<int>(type: "integer", nullable: false),
                    Email = table.Column<string>(type: "varchar(2000)", nullable: false),
                    EnderecoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIOS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_USUARIOS_ENDERECOS_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "ENDERECOS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PRODUTOS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    CategoriaId = table.Column<Guid>(type: "uuid", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(2000)", nullable: false),
                    PrecoCusto = table.Column<decimal>(type: "numeric", nullable: false),
                    PrecoVenda = table.Column<decimal>(type: "numeric", nullable: false),
                    PrecoPromocional = table.Column<decimal>(type: "numeric", nullable: false),
                    imagens = table.Column<List<string>>(type: "text[]", nullable: true),
                    Sku = table.Column<string>(type: "text", nullable: true),
                    Url = table.Column<string>(type: "varchar(200)", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    FornecedorId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUTOS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PRODUTOS_C_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "C",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PRODUTOS_FORNECEDORES_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "FORNECEDORES",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTOS_CategoriaId",
                table: "PRODUTOS",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTOS_FornecedorId",
                table: "PRODUTOS",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOS_EnderecoId",
                table: "USUARIOS",
                column: "EnderecoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRODUTOS");

            migrationBuilder.DropTable(
                name: "USUARIOS");

            migrationBuilder.DropTable(
                name: "C");

            migrationBuilder.DropTable(
                name: "FORNECEDORES");

            migrationBuilder.DropTable(
                name: "ENDERECOS");
        }
    }
}
