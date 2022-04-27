using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaWebPedidos.Infrastructure.Migrations
{
    public partial class produtosimagens1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SOBRE",
                keyColumn: "Id",
                keyValue: new Guid("971c4dcc-33f8-4a51-9b70-f34ee4c60282"));

            migrationBuilder.DropColumn(
                name: "Imagens",
                table: "PRODUTOS");

            migrationBuilder.AddColumn<string>(
                name: "Imagem1",
                table: "PRODUTOS",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Imagem2",
                table: "PRODUTOS",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Imagem3",
                table: "PRODUTOS",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Imagem4",
                table: "PRODUTOS",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Imagem5",
                table: "PRODUTOS",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "SOBRE",
                columns: new[] { "Id", "Cnpj", "ContatoPrincipal", "ContatoSecundario", "Cpf", "Descricao", "Email", "EnderecoId", "HorarioAbertura", "HorarioFechamento", "NomeEstabelecimento", "PessoaFisica", "RazaoSocial" },
                values: new object[] { new Guid("ee8ac6cf-e9b3-4704-9f8c-c35ba72bc0b8"), null, null, null, null, "Escreve aqui a Descrição", null, null, new TimeOnly(0, 0, 0), new TimeOnly(0, 0, 0), "Nome do Estabelecimento", false, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SOBRE",
                keyColumn: "Id",
                keyValue: new Guid("ee8ac6cf-e9b3-4704-9f8c-c35ba72bc0b8"));

            migrationBuilder.DropColumn(
                name: "Imagem1",
                table: "PRODUTOS");

            migrationBuilder.DropColumn(
                name: "Imagem2",
                table: "PRODUTOS");

            migrationBuilder.DropColumn(
                name: "Imagem3",
                table: "PRODUTOS");

            migrationBuilder.DropColumn(
                name: "Imagem4",
                table: "PRODUTOS");

            migrationBuilder.DropColumn(
                name: "Imagem5",
                table: "PRODUTOS");

            migrationBuilder.AddColumn<List<string>>(
                name: "Imagens",
                table: "PRODUTOS",
                type: "text[]",
                nullable: true);

            migrationBuilder.InsertData(
                table: "SOBRE",
                columns: new[] { "Id", "Cnpj", "ContatoPrincipal", "ContatoSecundario", "Cpf", "Descricao", "Email", "EnderecoId", "HorarioAbertura", "HorarioFechamento", "NomeEstabelecimento", "PessoaFisica", "RazaoSocial" },
                values: new object[] { new Guid("971c4dcc-33f8-4a51-9b70-f34ee4c60282"), null, null, null, null, "Escreve aqui a Descrição", null, null, new TimeOnly(0, 0, 0), new TimeOnly(0, 0, 0), "Nome do Estabelecimento", false, null });
        }
    }
}
