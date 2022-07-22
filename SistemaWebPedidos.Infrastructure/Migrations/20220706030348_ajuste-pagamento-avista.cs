using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaWebPedidos.Infrastructure.Migrations
{
    public partial class ajustepagamentoavista : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MEIO_PAGAMENTO",
                keyColumn: "Id",
                keyValue: new Guid("372d5011-c1fb-4999-8849-2eaea720ea99"));

            migrationBuilder.DeleteData(
                table: "MEIO_PAGAMENTO",
                keyColumn: "Id",
                keyValue: new Guid("86b93476-a5e7-4dc4-a92f-b1d84a65f6b1"));

            migrationBuilder.DeleteData(
                table: "MEIO_PAGAMENTO",
                keyColumn: "Id",
                keyValue: new Guid("da07084d-5a03-4b30-9087-9a1f4fc229ab"));

            migrationBuilder.DeleteData(
                table: "SOBRE",
                keyColumn: "Id",
                keyValue: new Guid("8b8b7dd4-d9b6-4f51-a4a8-746e30d1d0e6"));

            migrationBuilder.InsertData(
                table: "MEIO_PAGAMENTO",
                columns: new[] { "Id", "Ativo", "Img", "Nome", "NumMaxParcelamento", "ValorMinParcela" },
                values: new object[,]
                {
                    { new Guid("519412af-51f3-45d9-bc48-cab03010c371"), true, "https://w7.pngwing.com/pngs/371/4/png-transparent-visa-debit-card-credit-card-logo-mastercard-visa-text-trademark-logo.png", "Cartão Master", 6, 50.0 },
                    { new Guid("9948cf88-16ae-4361-9b62-9a7702565210"), true, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT7MsT24vvFA5FqSn2vhmwjR3IFKLKZvekhOg&usqp=CAU", "Dinheiro ou Pix", 1, 999999999.0 },
                    { new Guid("da8c8af9-6fe2-43ef-9961-2a3739e883dd"), true, "https://logosmarcas.net/wp-content/uploads/2020/09/MasterCard-Logo-1990-1996.png", "Cartão VISA", 10, 20.0 }
                });

            migrationBuilder.InsertData(
                table: "SOBRE",
                columns: new[] { "Id", "Bairro", "Cidade", "Cnpj", "ContatoPrincipal", "ContatoSecundario", "Cpf", "Descricao", "Email", "Estado", "HorarioAbertura", "HorarioFechamento", "Imagem1", "NomeEstabelecimento", "Numero", "PessoaFisica", "RazaoSocial", "Rua" },
                values: new object[] { new Guid("13c398cc-27f5-4c9d-ae4e-315fee4cb3bf"), null, null, null, null, null, null, "Escreve aqui a Descrição", null, null, null, null, null, "Nome do Estabelecimento", null, false, null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MEIO_PAGAMENTO",
                keyColumn: "Id",
                keyValue: new Guid("519412af-51f3-45d9-bc48-cab03010c371"));

            migrationBuilder.DeleteData(
                table: "MEIO_PAGAMENTO",
                keyColumn: "Id",
                keyValue: new Guid("9948cf88-16ae-4361-9b62-9a7702565210"));

            migrationBuilder.DeleteData(
                table: "MEIO_PAGAMENTO",
                keyColumn: "Id",
                keyValue: new Guid("da8c8af9-6fe2-43ef-9961-2a3739e883dd"));

            migrationBuilder.DeleteData(
                table: "SOBRE",
                keyColumn: "Id",
                keyValue: new Guid("13c398cc-27f5-4c9d-ae4e-315fee4cb3bf"));

            migrationBuilder.InsertData(
                table: "MEIO_PAGAMENTO",
                columns: new[] { "Id", "Ativo", "Img", "Nome", "NumMaxParcelamento", "ValorMinParcela" },
                values: new object[,]
                {
                    { new Guid("372d5011-c1fb-4999-8849-2eaea720ea99"), true, "https://logosmarcas.net/wp-content/uploads/2020/09/MasterCard-Logo-1990-1996.png", "Cartão VISA", 10, 20.0 },
                    { new Guid("86b93476-a5e7-4dc4-a92f-b1d84a65f6b1"), true, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT7MsT24vvFA5FqSn2vhmwjR3IFKLKZvekhOg&usqp=CAU", "Dinheiro ou Pix", 999999999, 1.0 },
                    { new Guid("da07084d-5a03-4b30-9087-9a1f4fc229ab"), true, "https://w7.pngwing.com/pngs/371/4/png-transparent-visa-debit-card-credit-card-logo-mastercard-visa-text-trademark-logo.png", "Cartão Master", 6, 50.0 }
                });

            migrationBuilder.InsertData(
                table: "SOBRE",
                columns: new[] { "Id", "Bairro", "Cidade", "Cnpj", "ContatoPrincipal", "ContatoSecundario", "Cpf", "Descricao", "Email", "Estado", "HorarioAbertura", "HorarioFechamento", "Imagem1", "NomeEstabelecimento", "Numero", "PessoaFisica", "RazaoSocial", "Rua" },
                values: new object[] { new Guid("8b8b7dd4-d9b6-4f51-a4a8-746e30d1d0e6"), null, null, null, null, null, null, "Escreve aqui a Descrição", null, null, null, null, null, "Nome do Estabelecimento", null, false, null, null });
        }
    }
}
