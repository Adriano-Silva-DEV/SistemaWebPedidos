using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaWebPedidos.Infrastructure.Migrations
{
    public partial class datacriacao1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SOBRE",
                keyColumn: "Id",
                keyValue: new Guid("2e7994cc-06c0-4b36-8635-d15942a8c4e0"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "dataCriacao",
                table: "PRODUTOS",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.InsertData(
                table: "SOBRE",
                columns: new[] { "Id", "Cnpj", "ContatoPrincipal", "ContatoSecundario", "Cpf", "Descricao", "Email", "EnderecoId", "HorarioAbertura", "HorarioFechamento", "NomeEstabelecimento", "PessoaFisica", "RazaoSocial" },
                values: new object[] { new Guid("dc78785d-6fd4-4a26-8aca-e1e69cd9ebce"), null, null, null, null, "Escreve aqui a Descrição", null, null, new TimeOnly(0, 0, 0), new TimeOnly(0, 0, 0), "Nome do Estabelecimento", false, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SOBRE",
                keyColumn: "Id",
                keyValue: new Guid("dc78785d-6fd4-4a26-8aca-e1e69cd9ebce"));

            migrationBuilder.AlterColumn<DateOnly>(
                name: "dataCriacao",
                table: "PRODUTOS",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.InsertData(
                table: "SOBRE",
                columns: new[] { "Id", "Cnpj", "ContatoPrincipal", "ContatoSecundario", "Cpf", "Descricao", "Email", "EnderecoId", "HorarioAbertura", "HorarioFechamento", "NomeEstabelecimento", "PessoaFisica", "RazaoSocial" },
                values: new object[] { new Guid("2e7994cc-06c0-4b36-8635-d15942a8c4e0"), null, null, null, null, "Escreve aqui a Descrição", null, null, new TimeOnly(0, 0, 0), new TimeOnly(0, 0, 0), "Nome do Estabelecimento", false, null });
        }
    }
}
