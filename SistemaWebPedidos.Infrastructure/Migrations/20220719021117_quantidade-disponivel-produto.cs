using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaWebPedidos.Infrastructure.Migrations
{
    public partial class quantidadedisponivelproduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SOBRE",
                keyColumn: "Id",
                keyValue: new Guid("79b36436-bc03-45dc-853e-360cf45e8d89"));

            migrationBuilder.AddColumn<int>(
                name: "QuantidadeDisponivel",
                table: "PRODUTOS",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "SOBRE",
                columns: new[] { "Id", "Bairro", "Cidade", "Cnpj", "ContatoPrincipal", "ContatoSecundario", "Cpf", "Descricao", "Email", "Estado", "HorarioAbertura", "HorarioFechamento", "Imagem1", "NomeEstabelecimento", "Numero", "PessoaFisica", "RazaoSocial", "Rua" },
                values: new object[] { new Guid("5be5adfc-4d7d-4740-8770-3a716696aac2"), null, null, null, null, null, null, "Escreve aqui a Descrição", null, null, null, null, null, "Nome do Estabelecimento", null, false, null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SOBRE",
                keyColumn: "Id",
                keyValue: new Guid("5be5adfc-4d7d-4740-8770-3a716696aac2"));

            migrationBuilder.DropColumn(
                name: "QuantidadeDisponivel",
                table: "PRODUTOS");

            migrationBuilder.InsertData(
                table: "SOBRE",
                columns: new[] { "Id", "Bairro", "Cidade", "Cnpj", "ContatoPrincipal", "ContatoSecundario", "Cpf", "Descricao", "Email", "Estado", "HorarioAbertura", "HorarioFechamento", "Imagem1", "NomeEstabelecimento", "Numero", "PessoaFisica", "RazaoSocial", "Rua" },
                values: new object[] { new Guid("79b36436-bc03-45dc-853e-360cf45e8d89"), null, null, null, null, null, null, "Escreve aqui a Descrição", null, null, null, null, null, "Nome do Estabelecimento", null, false, null, null });
        }
    }
}
