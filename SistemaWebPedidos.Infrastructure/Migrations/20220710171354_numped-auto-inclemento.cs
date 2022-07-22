using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SistemaWebPedidos.Infrastructure.Migrations
{
    public partial class numpedautoinclemento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MEIO_PAGAMENTO",
                keyColumn: "Id",
                keyValue: new Guid("45b874a9-67ec-43ca-9958-98a6805d85ca"));

            migrationBuilder.DeleteData(
                table: "MEIO_PAGAMENTO",
                keyColumn: "Id",
                keyValue: new Guid("81380124-9f22-49a8-92ca-f798a951ee43"));

            migrationBuilder.DeleteData(
                table: "MEIO_PAGAMENTO",
                keyColumn: "Id",
                keyValue: new Guid("87916bbe-c1b1-42cd-860d-9203cf2ddfa8"));

            migrationBuilder.DeleteData(
                table: "SOBRE",
                keyColumn: "Id",
                keyValue: new Guid("fd1954bd-9729-48af-ba85-2fd7a9869674"));

            migrationBuilder.AddColumn<int>(
                name: "NumeroPedido",
                table: "PEDIDOS",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.InsertData(
                table: "MEIO_PAGAMENTO",
                columns: new[] { "Id", "Ativo", "Img", "Nome", "NumMaxParcelamento", "ValorMinParcela" },
                values: new object[,]
                {
                    { new Guid("21aaa660-be61-43be-ba31-08b044ac04c1"), true, "https://w7.pngwing.com/pngs/371/4/png-transparent-visa-debit-card-credit-card-logo-mastercard-visa-text-trademark-logo.png", "Cartão Master", 6, 50.0 },
                    { new Guid("32abc88f-b734-404d-a23a-ff629ff69de7"), true, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT7MsT24vvFA5FqSn2vhmwjR3IFKLKZvekhOg&usqp=CAU", "Dinheiro ou Pix", 1, 999999999.0 },
                    { new Guid("849dc3be-f82e-41b8-aec9-1afa806edc1d"), true, "https://logosmarcas.net/wp-content/uploads/2020/09/MasterCard-Logo-1990-1996.png", "Cartão VISA", 10, 20.0 }
                });

            migrationBuilder.InsertData(
                table: "SOBRE",
                columns: new[] { "Id", "Bairro", "Cidade", "Cnpj", "ContatoPrincipal", "ContatoSecundario", "Cpf", "Descricao", "Email", "Estado", "HorarioAbertura", "HorarioFechamento", "Imagem1", "NomeEstabelecimento", "Numero", "PessoaFisica", "RazaoSocial", "Rua" },
                values: new object[] { new Guid("4da4287b-b164-4b59-a39c-fe3e560f2369"), null, null, null, null, null, null, "Escreve aqui a Descrição", null, null, null, null, null, "Nome do Estabelecimento", null, false, null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MEIO_PAGAMENTO",
                keyColumn: "Id",
                keyValue: new Guid("21aaa660-be61-43be-ba31-08b044ac04c1"));

            migrationBuilder.DeleteData(
                table: "MEIO_PAGAMENTO",
                keyColumn: "Id",
                keyValue: new Guid("32abc88f-b734-404d-a23a-ff629ff69de7"));

            migrationBuilder.DeleteData(
                table: "MEIO_PAGAMENTO",
                keyColumn: "Id",
                keyValue: new Guid("849dc3be-f82e-41b8-aec9-1afa806edc1d"));

            migrationBuilder.DeleteData(
                table: "SOBRE",
                keyColumn: "Id",
                keyValue: new Guid("4da4287b-b164-4b59-a39c-fe3e560f2369"));

            migrationBuilder.DropColumn(
                name: "NumeroPedido",
                table: "PEDIDOS");

            migrationBuilder.InsertData(
                table: "MEIO_PAGAMENTO",
                columns: new[] { "Id", "Ativo", "Img", "Nome", "NumMaxParcelamento", "ValorMinParcela" },
                values: new object[,]
                {
                    { new Guid("45b874a9-67ec-43ca-9958-98a6805d85ca"), true, "https://logosmarcas.net/wp-content/uploads/2020/09/MasterCard-Logo-1990-1996.png", "Cartão VISA", 10, 20.0 },
                    { new Guid("81380124-9f22-49a8-92ca-f798a951ee43"), true, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT7MsT24vvFA5FqSn2vhmwjR3IFKLKZvekhOg&usqp=CAU", "Dinheiro ou Pix", 1, 999999999.0 },
                    { new Guid("87916bbe-c1b1-42cd-860d-9203cf2ddfa8"), true, "https://w7.pngwing.com/pngs/371/4/png-transparent-visa-debit-card-credit-card-logo-mastercard-visa-text-trademark-logo.png", "Cartão Master", 6, 50.0 }
                });

            migrationBuilder.InsertData(
                table: "SOBRE",
                columns: new[] { "Id", "Bairro", "Cidade", "Cnpj", "ContatoPrincipal", "ContatoSecundario", "Cpf", "Descricao", "Email", "Estado", "HorarioAbertura", "HorarioFechamento", "Imagem1", "NomeEstabelecimento", "Numero", "PessoaFisica", "RazaoSocial", "Rua" },
                values: new object[] { new Guid("fd1954bd-9729-48af-ba85-2fd7a9869674"), null, null, null, null, null, null, "Escreve aqui a Descrição", null, null, null, null, null, "Nome do Estabelecimento", null, false, null, null });
        }
    }
}
