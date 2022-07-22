using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaWebPedidos.Infrastructure.Migrations
{
    public partial class addproduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<Guid>(
                name: "ProdutoId",
                table: "ItensPedidos",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<Guid>(
                name: "ProdutoId",
                table: "ItensPedidos",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

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
    }
}
