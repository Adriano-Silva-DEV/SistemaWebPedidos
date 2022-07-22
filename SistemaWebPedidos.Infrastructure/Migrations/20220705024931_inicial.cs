using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaWebPedidos.Infrastructure.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CATEGORIAS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORIAS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ENDERECOS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Numero = table.Column<string>(type: "text", nullable: true),
                    Rua = table.Column<string>(type: "varchar(200)", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(50)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(30)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENDERECOS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FORNECEDORES",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    Documento = table.Column<string>(type: "varchar(14)", nullable: false),
                    TipoFornecedor = table.Column<int>(type: "integer", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FORNECEDORES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MEIO_PAGAMENTO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    NumMaxParcelamento = table.Column<int>(type: "integer", nullable: false),
                    ValorMinParcela = table.Column<double>(type: "double precision", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    Img = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MEIO_PAGAMENTO", x => x.Id);
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
                    HorarioAbertura = table.Column<string>(type: "text", nullable: true),
                    HorarioFechamento = table.Column<string>(type: "text", nullable: true),
                    Descricao = table.Column<string>(type: "varchar(300)", nullable: true),
                    ContatoPrincipal = table.Column<string>(type: "text", nullable: true),
                    ContatoSecundario = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Numero = table.Column<string>(type: "text", nullable: true),
                    Rua = table.Column<string>(type: "varchar(200)", nullable: true),
                    Bairro = table.Column<string>(type: "varchar(50)", nullable: true),
                    Cidade = table.Column<string>(type: "varchar(30)", nullable: true),
                    Estado = table.Column<string>(type: "varchar(30)", nullable: true),
                    Imagem1 = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SOBRE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "USUARIOS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdIdentity = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    Sobrenome = table.Column<string>(type: "text", nullable: true),
                    Telefone = table.Column<string>(type: "text", nullable: true),
                    EnderecoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIOS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_USUARIOS_ENDERECOS_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "ENDERECOS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PRODUTOS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    CategoriaId = table.Column<Guid>(type: "uuid", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(2000)", nullable: false),
                    PrecoCusto = table.Column<decimal>(type: "numeric", nullable: false),
                    PrecoVenda = table.Column<decimal>(type: "numeric", nullable: false),
                    PrecoPromocional = table.Column<decimal>(type: "numeric", nullable: false),
                    Imagem1 = table.Column<string>(type: "text", nullable: true),
                    Imagem2 = table.Column<string>(type: "text", nullable: true),
                    Imagem3 = table.Column<string>(type: "text", nullable: true),
                    Imagem4 = table.Column<string>(type: "text", nullable: true),
                    Imagem5 = table.Column<string>(type: "text", nullable: true),
                    Sku = table.Column<string>(type: "text", nullable: true),
                    Url = table.Column<string>(type: "varchar(200)", nullable: true),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    FornecedorId = table.Column<Guid>(type: "uuid", nullable: false),
                    dataCadastro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUTOS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PRODUTOS_CATEGORIAS_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "CATEGORIAS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PRODUTOS_FORNECEDORES_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "FORNECEDORES",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PEDIDOS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uuid", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "numeric", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EnderecoEntregaId = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: true),
                    MeioPagamentoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PEDIDOS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PEDIDOS_ENDERECOS_EnderecoEntregaId",
                        column: x => x.EnderecoEntregaId,
                        principalTable: "ENDERECOS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PEDIDOS_MEIO_PAGAMENTO_MeioPagamentoId",
                        column: x => x.MeioPagamentoId,
                        principalTable: "MEIO_PAGAMENTO",
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
                    PedidoId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensPedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItensPedidos_PEDIDOS_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "PEDIDOS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ItensPedidos_PRODUTOS_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "PRODUTOS",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "SOBRE",
                columns: new[] { "Id", "Bairro", "Cidade", "Cnpj", "ContatoPrincipal", "ContatoSecundario", "Cpf", "Descricao", "Email", "Estado", "HorarioAbertura", "HorarioFechamento", "Imagem1", "NomeEstabelecimento", "Numero", "PessoaFisica", "RazaoSocial", "Rua" },
                values: new object[] { new Guid("12273761-4d30-4af2-92ce-e27fc379d4c8"), null, null, null, null, null, null, "Escreve aqui a Descrição", null, null, null, null, null, "Nome do Estabelecimento", null, false, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedidos_PedidoId",
                table: "ItensPedidos",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedidos_ProdutoId",
                table: "ItensPedidos",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_PEDIDOS_EnderecoEntregaId",
                table: "PEDIDOS",
                column: "EnderecoEntregaId");

            migrationBuilder.CreateIndex(
                name: "IX_PEDIDOS_MeioPagamentoId",
                table: "PEDIDOS",
                column: "MeioPagamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTOS_CategoriaId",
                table: "PRODUTOS",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTOS_FornecedorId",
                table: "PRODUTOS",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIOS_EnderecoId",
                table: "USUARIOS",
                column: "EnderecoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItensPedidos");

            migrationBuilder.DropTable(
                name: "SOBRE");

            migrationBuilder.DropTable(
                name: "USUARIOS");

            migrationBuilder.DropTable(
                name: "PEDIDOS");

            migrationBuilder.DropTable(
                name: "PRODUTOS");

            migrationBuilder.DropTable(
                name: "ENDERECOS");

            migrationBuilder.DropTable(
                name: "MEIO_PAGAMENTO");

            migrationBuilder.DropTable(
                name: "CATEGORIAS");

            migrationBuilder.DropTable(
                name: "FORNECEDORES");
        }
    }
}
