﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SistemaWebPedidos.Infrastructure.Persistence;

#nullable disable

namespace SistemaWebPedidos.Infrastructure.Migrations
{
    [DbContext(typeof(ApiDbContext))]
    partial class ApiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SistemaWebPedidos.Core.Entities.Categoria", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("CATEGORIAS", (string)null);
                });

            modelBuilder.Entity("SistemaWebPedidos.Core.Entities.Endereco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Numero")
                        .HasColumnType("text");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("ENDERECOS", (string)null);
                });

            modelBuilder.Entity("SistemaWebPedidos.Core.Entities.Fornecedor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean");

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasColumnType("varchar(14)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<int>("TipoFornecedor")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("FORNECEDORES", (string)null);
                });

            modelBuilder.Entity("SistemaWebPedidos.Core.Entities.ItemPedido", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("PedidoId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProdutoId")
                        .HasColumnType("uuid");

                    b.Property<int>("Quantidade")
                        .HasColumnType("integer");

                    b.Property<decimal>("ValorSemDesconto")
                        .HasColumnType("numeric");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("PedidoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("ItensPedidos");
                });

            modelBuilder.Entity("SistemaWebPedidos.Core.Entities.MeioPagamento", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean");

                    b.Property<string>("Img")
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .HasColumnType("text");

                    b.Property<int>("NumMaxParcelamento")
                        .HasColumnType("integer");

                    b.Property<double>("ValorMinParcela")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("MEIO_PAGAMENTO", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("32abc88f-b734-404d-a23a-ff629ff69de7"),
                            Ativo = true,
                            Img = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT7MsT24vvFA5FqSn2vhmwjR3IFKLKZvekhOg&usqp=CAU",
                            Nome = "Dinheiro ou Pix",
                            NumMaxParcelamento = 1,
                            ValorMinParcela = 999999999.0
                        },
                        new
                        {
                            Id = new Guid("849dc3be-f82e-41b8-aec9-1afa806edc1d"),
                            Ativo = true,
                            Img = "https://logosmarcas.net/wp-content/uploads/2020/09/MasterCard-Logo-1990-1996.png",
                            Nome = "Cartão VISA",
                            NumMaxParcelamento = 10,
                            ValorMinParcela = 20.0
                        },
                        new
                        {
                            Id = new Guid("21aaa660-be61-43be-ba31-08b044ac04c1"),
                            Ativo = true,
                            Img = "https://w7.pngwing.com/pngs/371/4/png-transparent-visa-debit-card-credit-card-logo-mastercard-visa-text-trademark-logo.png",
                            Nome = "Cartão Master",
                            NumMaxParcelamento = 6,
                            ValorMinParcela = 50.0
                        });
                });

            modelBuilder.Entity("SistemaWebPedidos.Core.Entities.Pedido", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("EnderecoEntregaId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("MeioPagamentoId")
                        .HasColumnType("uuid");

                    b.Property<int>("NumeroPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("NumeroPedido"));

                    b.Property<int>("QuantidadeParcela")
                        .HasColumnType("integer");

                    b.Property<string>("Status")
                        .HasColumnType("text");

                    b.Property<double?>("Troco")
                        .HasColumnType("double precision");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("ValorTotal")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoEntregaId");

                    b.HasIndex("MeioPagamentoId");

                    b.ToTable("PEDIDOS", (string)null);
                });

            modelBuilder.Entity("SistemaWebPedidos.Core.Entities.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean");

                    b.Property<Guid>("CategoriaId")
                        .HasColumnType("uuid");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(2000)");

                    b.Property<bool>("Excluido")
                        .HasColumnType("boolean");

                    b.Property<Guid>("FornecedorId")
                        .HasColumnType("uuid");

                    b.Property<string>("Imagem1")
                        .HasColumnType("text");

                    b.Property<string>("Imagem2")
                        .HasColumnType("text");

                    b.Property<string>("Imagem3")
                        .HasColumnType("text");

                    b.Property<string>("Imagem4")
                        .HasColumnType("text");

                    b.Property<string>("Imagem5")
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<decimal>("PrecoCusto")
                        .HasColumnType("numeric");

                    b.Property<decimal>("PrecoPromocional")
                        .HasColumnType("numeric");

                    b.Property<decimal>("PrecoVenda")
                        .HasColumnType("numeric");

                    b.Property<int>("QuantidadeDisponivel")
                        .HasColumnType("integer");

                    b.Property<string>("Sku")
                        .HasColumnType("text");

                    b.Property<string>("Url")
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime>("dataCadastro")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("FornecedorId");

                    b.ToTable("PRODUTOS", (string)null);
                });

            modelBuilder.Entity("SistemaWebPedidos.Core.Entities.Sobre", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Bairro")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Cidade")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Cnpj")
                        .HasColumnType("varchar(300)");

                    b.Property<string>("ContatoPrincipal")
                        .HasColumnType("text");

                    b.Property<string>("ContatoSecundario")
                        .HasColumnType("text");

                    b.Property<string>("Cpf")
                        .HasColumnType("varchar(11)");

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Estado")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("HorarioAbertura")
                        .HasColumnType("text");

                    b.Property<string>("HorarioFechamento")
                        .HasColumnType("text");

                    b.Property<string>("Imagem1")
                        .HasColumnType("text");

                    b.Property<string>("NomeEstabelecimento")
                        .HasColumnType("text");

                    b.Property<string>("Numero")
                        .HasColumnType("text");

                    b.Property<bool>("PessoaFisica")
                        .HasColumnType("boolean");

                    b.Property<string>("RazaoSocial")
                        .HasColumnType("text");

                    b.Property<string>("Rua")
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("SOBRE", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("5be5adfc-4d7d-4740-8770-3a716696aac2"),
                            Descricao = "Escreve aqui a Descrição",
                            NomeEstabelecimento = "Nome do Estabelecimento",
                            PessoaFisica = false
                        });
                });

            modelBuilder.Entity("SistemaWebPedidos.Core.Entities.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("EnderecoId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdIdentity")
                        .HasColumnType("uuid");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("text");

                    b.Property<string>("Telefone")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId")
                        .IsUnique();

                    b.ToTable("USUARIOS", (string)null);
                });

            modelBuilder.Entity("SistemaWebPedidos.Core.Entities.ItemPedido", b =>
                {
                    b.HasOne("SistemaWebPedidos.Core.Entities.Pedido", "Pedido")
                        .WithMany("ItensPedido")
                        .HasForeignKey("PedidoId")
                        .IsRequired();

                    b.HasOne("SistemaWebPedidos.Core.Entities.Produto", "Produto")
                        .WithMany("ItemPedido")
                        .HasForeignKey("ProdutoId")
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("SistemaWebPedidos.Core.Entities.Pedido", b =>
                {
                    b.HasOne("SistemaWebPedidos.Core.Entities.Endereco", "EnderecoEntrega")
                        .WithMany()
                        .HasForeignKey("EnderecoEntregaId")
                        .IsRequired();

                    b.HasOne("SistemaWebPedidos.Core.Entities.MeioPagamento", "MeioPagamento")
                        .WithMany("Pedido")
                        .HasForeignKey("MeioPagamentoId")
                        .IsRequired();

                    b.Navigation("EnderecoEntrega");

                    b.Navigation("MeioPagamento");
                });

            modelBuilder.Entity("SistemaWebPedidos.Core.Entities.Produto", b =>
                {
                    b.HasOne("SistemaWebPedidos.Core.Entities.Categoria", "Categoria")
                        .WithMany("Produtos")
                        .HasForeignKey("CategoriaId")
                        .IsRequired();

                    b.HasOne("SistemaWebPedidos.Core.Entities.Fornecedor", "Fornecedor")
                        .WithMany("Produtos")
                        .HasForeignKey("FornecedorId")
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Fornecedor");
                });

            modelBuilder.Entity("SistemaWebPedidos.Core.Entities.Usuario", b =>
                {
                    b.HasOne("SistemaWebPedidos.Core.Entities.Endereco", "Endereco")
                        .WithOne("Usuario")
                        .HasForeignKey("SistemaWebPedidos.Core.Entities.Usuario", "EnderecoId")
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("SistemaWebPedidos.Core.Entities.Categoria", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("SistemaWebPedidos.Core.Entities.Endereco", b =>
                {
                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("SistemaWebPedidos.Core.Entities.Fornecedor", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("SistemaWebPedidos.Core.Entities.MeioPagamento", b =>
                {
                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("SistemaWebPedidos.Core.Entities.Pedido", b =>
                {
                    b.Navigation("ItensPedido");
                });

            modelBuilder.Entity("SistemaWebPedidos.Core.Entities.Produto", b =>
                {
                    b.Navigation("ItemPedido");
                });
#pragma warning restore 612, 618
        }
    }
}
