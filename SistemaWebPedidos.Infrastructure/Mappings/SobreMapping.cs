using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaWebPedidos.Core.Entities;

namespace SistemaWebPedidos.Infrastructure.Mappings
{
    public class SobreMapping : IEntityTypeConfiguration<Sobre>
        {
            public void Configure(EntityTypeBuilder<Sobre> builder)
            {
                builder.HasKey(p => p.Id);

                builder.Property(p => p.Cpf)         
                    .HasColumnType("varchar(11)");

            builder.Property(p => p.Cnpj)
                    .HasColumnType("varchar(300)");

            builder.Property(p => p.Descricao)
                    .HasColumnType("varchar(300)");
               
            builder.ToTable("SOBRE");

            builder.Property(p => p.Rua)
                   .HasColumnType("varchar(200)");

            builder.Property(p => p.Cidade)
                .HasColumnType("varchar(30)");

            builder.Property(p => p.Bairro)
                .HasColumnType("varchar(50)");

            builder.Property(p => p.Estado)
                .HasColumnType("varchar(30)");

            builder.HasData(
                new Sobre
                {
                    NomeEstabelecimento = "Nome do Estabelecimento",
                    Descricao = "Escreve aqui a Descrição"               
                }
                ); 
            }
             
        }
}
