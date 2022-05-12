using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaWebPedidos.Infrastructure.Migrations
{
    public partial class g : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SOBRE_ENDERECOS_EnderecoId",
                table: "SOBRE");

            migrationBuilder.DropIndex(
                name: "IX_SOBRE_EnderecoId",
                table: "SOBRE");

            migrationBuilder.DeleteData(
                table: "SOBRE",
                keyColumn: "Id",
                keyValue: new Guid("e34a22d0-5437-4ef4-8c7b-99ffacd272b7"));

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "SOBRE");

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "SOBRE",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "SOBRE",
                type: "varchar(30)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "SOBRE",
                type: "varchar(30)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "SOBRE",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rua",
                table: "SOBRE",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "SOBRE",
                columns: new[] { "Id", "Bairro", "Cidade", "Cnpj", "ContatoPrincipal", "ContatoSecundario", "Cpf", "Descricao", "Email", "Estado", "HorarioAbertura", "HorarioFechamento", "NomeEstabelecimento", "Numero", "PessoaFisica", "RazaoSocial", "Rua" },
                values: new object[] { new Guid("9b7efdf9-af85-46a2-a608-5f17644dcfb2"), null, null, null, null, null, null, "Escreve aqui a Descrição", null, null, null, null, "Nome do Estabelecimento", null, false, null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SOBRE",
                keyColumn: "Id",
                keyValue: new Guid("9b7efdf9-af85-46a2-a608-5f17644dcfb2"));

            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "SOBRE");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "SOBRE");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "SOBRE");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "SOBRE");

            migrationBuilder.DropColumn(
                name: "Rua",
                table: "SOBRE");

            migrationBuilder.AddColumn<Guid>(
                name: "EnderecoId",
                table: "SOBRE",
                type: "uuid",
                nullable: true);

            migrationBuilder.InsertData(
                table: "SOBRE",
                columns: new[] { "Id", "Cnpj", "ContatoPrincipal", "ContatoSecundario", "Cpf", "Descricao", "Email", "EnderecoId", "HorarioAbertura", "HorarioFechamento", "NomeEstabelecimento", "PessoaFisica", "RazaoSocial" },
                values: new object[] { new Guid("e34a22d0-5437-4ef4-8c7b-99ffacd272b7"), null, null, null, null, "Escreve aqui a Descrição", null, null, null, null, "Nome do Estabelecimento", false, null });

            migrationBuilder.CreateIndex(
                name: "IX_SOBRE_EnderecoId",
                table: "SOBRE",
                column: "EnderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_SOBRE_ENDERECOS_EnderecoId",
                table: "SOBRE",
                column: "EnderecoId",
                principalTable: "ENDERECOS",
                principalColumn: "Id");
        }
    }
}
