using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaWebPedidos.Infrastructure.Migrations
{
    public partial class datacriacao3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SOBRE",
                keyColumn: "Id",
                keyValue: new Guid("207223b8-e2c8-43cc-9b56-b2a2fd5459b5"));

            migrationBuilder.RenameColumn(
                name: "dataCriacao",
                table: "PRODUTOS",
                newName: "dataCadastro");

            migrationBuilder.InsertData(
                table: "SOBRE",
                columns: new[] { "Id", "Cnpj", "ContatoPrincipal", "ContatoSecundario", "Cpf", "Descricao", "Email", "EnderecoId", "HorarioAbertura", "HorarioFechamento", "NomeEstabelecimento", "PessoaFisica", "RazaoSocial" },
                values: new object[] { new Guid("007fc715-0405-4c2e-b371-eb24e57aa06e"), null, null, null, null, "Escreve aqui a Descrição", null, null, new TimeOnly(0, 0, 0), new TimeOnly(0, 0, 0), "Nome do Estabelecimento", false, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SOBRE",
                keyColumn: "Id",
                keyValue: new Guid("007fc715-0405-4c2e-b371-eb24e57aa06e"));

            migrationBuilder.RenameColumn(
                name: "dataCadastro",
                table: "PRODUTOS",
                newName: "dataCriacao");

            migrationBuilder.InsertData(
                table: "SOBRE",
                columns: new[] { "Id", "Cnpj", "ContatoPrincipal", "ContatoSecundario", "Cpf", "Descricao", "Email", "EnderecoId", "HorarioAbertura", "HorarioFechamento", "NomeEstabelecimento", "PessoaFisica", "RazaoSocial" },
                values: new object[] { new Guid("207223b8-e2c8-43cc-9b56-b2a2fd5459b5"), null, null, null, null, "Escreve aqui a Descrição", null, null, new TimeOnly(0, 0, 0), new TimeOnly(0, 0, 0), "Nome do Estabelecimento", false, null });
        }
    }
}
