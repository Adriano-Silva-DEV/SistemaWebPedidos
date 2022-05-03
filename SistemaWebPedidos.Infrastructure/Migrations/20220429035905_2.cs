using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaWebPedidos.Infrastructure.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SOBRE",
                keyColumn: "Id",
                keyValue: new Guid("ee8ac6cf-e9b3-4704-9f8c-c35ba72bc0b8"));

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "PRODUTOS",
                type: "varchar(200)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.InsertData(
                table: "SOBRE",
                columns: new[] { "Id", "Cnpj", "ContatoPrincipal", "ContatoSecundario", "Cpf", "Descricao", "Email", "EnderecoId", "HorarioAbertura", "HorarioFechamento", "NomeEstabelecimento", "PessoaFisica", "RazaoSocial" },
                values: new object[] { new Guid("105decf7-6f5d-4532-854f-ed97ccad247a"), null, null, null, null, "Escreve aqui a Descrição", null, null, new TimeOnly(0, 0, 0), new TimeOnly(0, 0, 0), "Nome do Estabelecimento", false, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SOBRE",
                keyColumn: "Id",
                keyValue: new Guid("105decf7-6f5d-4532-854f-ed97ccad247a"));

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "PRODUTOS",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "SOBRE",
                columns: new[] { "Id", "Cnpj", "ContatoPrincipal", "ContatoSecundario", "Cpf", "Descricao", "Email", "EnderecoId", "HorarioAbertura", "HorarioFechamento", "NomeEstabelecimento", "PessoaFisica", "RazaoSocial" },
                values: new object[] { new Guid("ee8ac6cf-e9b3-4704-9f8c-c35ba72bc0b8"), null, null, null, null, "Escreve aqui a Descrição", null, null, new TimeOnly(0, 0, 0), new TimeOnly(0, 0, 0), "Nome do Estabelecimento", false, null });
        }
    }
}
