using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaWebPedidos.Core.Entities;

namespace SistemaWebPedidos.Infrastructure.Mappings
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
        {
            public void Configure(EntityTypeBuilder<Endereco> builder)
            {
                builder.HasKey(p => p.Id);

                builder.Property(p => p.Rua)
                    .IsRequired()
                    .HasColumnType("varchar(200)");

                builder.Property(p => p.Cidade)
                    .IsRequired()
                    .HasColumnType("varchar(30)");

                builder.Property(p => p.Bairro)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                builder.Property(p => p.Estado)
                    .IsRequired()
                    .HasColumnType("varchar(30)");

            builder.HasOne(p => p.Usuario)
               .WithOne(f => f.Endereco);
             
               
           

            builder.ToTable("ENDERECOS");
            }
        }
}
