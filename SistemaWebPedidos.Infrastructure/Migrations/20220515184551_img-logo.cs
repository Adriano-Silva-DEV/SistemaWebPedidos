using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaWebPedidos.Infrastructure.Migrations
{
    public partial class imglogo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SOBRE",
                keyColumn: "Id",
                keyValue: new Guid("9b7efdf9-af85-46a2-a608-5f17644dcfb2"));

            migrationBuilder.AddColumn<string>(
                name: "Imagem1",
                table: "SOBRE",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "SOBRE",
                columns: new[] { "Id", "Bairro", "Cidade", "Cnpj", "ContatoPrincipal", "ContatoSecundario", "Cpf", "Descricao", "Email", "Estado", "HorarioAbertura", "HorarioFechamento", "Imagem1", "NomeEstabelecimento", "Numero", "PessoaFisica", "RazaoSocial", "Rua" },
                values: new object[] { new Guid("ef2da361-f527-4ade-9d15-26149e5cdce8"), null, null, null, null, null, null, "Escreve aqui a Descrição", null, null, null, null, null, "Nome do Estabelecimento", null, false, null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SOBRE",
                keyColumn: "Id",
                keyValue: new Guid("ef2da361-f527-4ade-9d15-26149e5cdce8"));

            migrationBuilder.DropColumn(
                name: "Imagem1",
                table: "SOBRE");

            migrationBuilder.InsertData(
                table: "SOBRE",
                columns: new[] { "Id", "Bairro", "Cidade", "Cnpj", "ContatoPrincipal", "ContatoSecundario", "Cpf", "Descricao", "Email", "Estado", "HorarioAbertura", "HorarioFechamento", "NomeEstabelecimento", "Numero", "PessoaFisica", "RazaoSocial", "Rua" },
                values: new object[] { new Guid("9b7efdf9-af85-46a2-a608-5f17644dcfb2"), null, null, null, null, null, null, "Escreve aqui a Descrição", null, null, null, null, "Nome do Estabelecimento", null, false, null, null });
        }
    }
}
