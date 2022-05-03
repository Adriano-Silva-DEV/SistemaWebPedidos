using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaWebPedidos.Infrastructure.Migrations
{
    public partial class produtosimagens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "USUARIOS");

            migrationBuilder.RenameColumn(
                name: "imagens",
                table: "PRODUTOS",
                newName: "Imagens");

            migrationBuilder.AddColumn<Guid>(
                name: "IdEntity",
                table: "USUARIOS",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Sobrenome",
                table: "USUARIOS",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uuid", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "numeric", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EnderecoEntregaId = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_ENDERECOS_EnderecoEntregaId",
                        column: x => x.EnderecoEntregaId,
                        principalTable: "ENDERECOS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SOBRE",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PessoaFisica = table.Column<bool>(type: "boolean", nullable: false),
                    Cnpj = table.Column<string>(type: "varchar(300)", nullable: true),
                    RazaoSocial = table.Column<string>(type: "text", nullable: true),
                    Cpf = table.Column<string>(type: "varchar(11)", nullable: true),
                    NomeEstabelecimento = table.Column<string>(type: "text", nullable: true),
                    HorarioAbertura = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    HorarioFechamento = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(300)", nullable: true),
                    ContatoPrincipal = table.Column<string>(type: "text", nullable: true),
                    ContatoSecundario = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    EnderecoId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SOBRE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SOBRE_ENDERECOS_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "ENDERECOS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ItensPedidos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProdutoId = table.Column<Guid>(type: "uuid", nullable: true),
                    Quantidade = table.Column<int>(type: "integer", nullable: false),
                    ValorSemDesconto = table.Column<decimal>(type: "numeric", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "numeric", nullable: false),
                    PedidoId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensPedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensPedidos_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ItensPedidos_PRODUTOS_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "PRODUTOS",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "SOBRE",
                columns: new[] { "Id", "Cnpj", "ContatoPrincipal", "ContatoSecundario", "Cpf", "Descricao", "Email", "EnderecoId", "HorarioAbertura", "HorarioFechamento", "NomeEstabelecimento", "PessoaFisica", "RazaoSocial" },
                values: new object[] { new Guid("971c4dcc-33f8-4a51-9b70-f34ee4c60282"), null, null, null, null, "Escreve aqui a Descrição", null, null, new TimeOnly(0, 0, 0), new TimeOnly(0, 0, 0), "Nome do Estabelecimento", false, null });

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedidos_PedidoId",
                table: "ItensPedidos",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedidos_ProdutoId",
                table: "ItensPedidos",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_EnderecoEntregaId",
                table: "Pedidos",
                column: "EnderecoEntregaId");

            migrationBuilder.CreateIndex(
                name: "IX_SOBRE_EnderecoId",
                table: "SOBRE",
                column: "EnderecoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItensPedidos");

            migrationBuilder.DropTable(
                name: "SOBRE");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropColumn(
                name: "IdEntity",
                table: "USUARIOS");

            migrationBuilder.DropColumn(
                name: "Sobrenome",
                table: "USUARIOS");

            migrationBuilder.RenameColumn(
                name: "Imagens",
                table: "PRODUTOS",
                newName: "imagens");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "USUARIOS",
                type: "varchar(2000)",
                nullable: false,
                defaultValue: "");
        }
    }
}
