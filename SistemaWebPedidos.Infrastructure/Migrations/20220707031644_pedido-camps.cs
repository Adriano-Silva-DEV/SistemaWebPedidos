using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaWebPedidos.Infrastructure.Migrations
{
    public partial class pedidocamps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "QuantidadeParcela",
                table: "PEDIDOS",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Troco",
                table: "PEDIDOS",
                type: "double precision",
                nullable: true);

            migrationBuilder.InsertData(
                table: "MEIO_PAGAMENTO",
                columns: new[] { "Id", "Ativo", "Img", "Nome", "NumMaxParcelamento", "ValorMinParcela" },
                values: new object[,]
                {
                    { new Guid("0fbd5b16-f1a7-4b6a-a904-6e893f6a4a34"), true, "https://logosmarcas.net/wp-content/uploads/2020/09/MasterCard-Logo-1990-1996.png", "Cartão VISA", 10, 20.0 },
                    { new Guid("35206789-c1ff-47f9-954a-51f7d31d74ac"), true, "https://w7.pngwing.com/pngs/371/4/png-transparent-visa-debit-card-credit-card-logo-mastercard-visa-text-trademark-logo.png", "Cartão Master", 6, 50.0 },
                    { new Guid("b90ebd8a-cf3c-4516-adf1-7f1c8add9789"), true, "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT7MsT24vvFA5FqSn2vhmwjR3IFKLKZvekhOg&usqp=CAU", "Dinheiro ou Pix", 1, 999999999.0 }
                });

            migrationBuilder.InsertData(
                table: "SOBRE",
                columns: new[] { "Id", "Bairro", "Cidade", "Cnpj", "ContatoPrincipal", "ContatoSecundario", "Cpf", "Descricao", "Email", "Estado", "HorarioAbertura", "HorarioFechamento", "Imagem1", "NomeEstabelecimento", "Numero", "PessoaFisica", "RazaoSocial", "Rua" },
                values: new object[] { new Guid("c7bcfc5d-8b43-4a19-93e6-391a815bb517"), null, null, null, null, null, null, "Escreve aqui a Descrição", null, null, null, null, null, "Nome do Estabelecimento", null, false, null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MEIO_PAGAMENTO",
                keyColumn: "Id",
                keyValue: new Guid("0fbd5b16-f1a7-4b6a-a904-6e893f6a4a34"));

            migrationBuilder.DeleteData(
                table: "MEIO_PAGAMENTO",
                keyColumn: "Id",
                keyValue: new Guid("35206789-c1ff-47f9-954a-51f7d31d74ac"));

            migrationBuilder.DeleteData(
                table: "MEIO_PAGAMENTO",
                keyColumn: "Id",
                keyValue: new Guid("b90ebd8a-cf3c-4516-adf1-7f1c8add9789"));

            migrationBuilder.DeleteData(
                table: "SOBRE",
                keyColumn: "Id",
                keyValue: new Guid("c7bcfc5d-8b43-4a19-93e6-391a815bb517"));

            migrationBuilder.DropColumn(
                name: "QuantidadeParcela",
                table: "PEDIDOS");

            migrationBuilder.DropColumn(
                name: "Troco",
                table: "PEDIDOS");

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
    }
}
