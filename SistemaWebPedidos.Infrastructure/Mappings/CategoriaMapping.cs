using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaWebPedidos.Core.Entities;

namespace SistemaWebPedidos.Infrastructure.Mappings
{
    public class CategoriaMapping : IEntityTypeConfiguration<Categoria>
        {
            public void Configure(EntityTypeBuilder<Categoria> builder)
            {
                builder.HasKey(p => p.Id);

                builder.Property(p => p.Nome)
                    .IsRequired()
                    .HasColumnType("varchar(200)");


            builder.HasMany(p => p.Produtos)
               .WithOne(c => c.Categoria)
               .HasForeignKey(f => f.CategoriaId);
                  

            builder.ToTable("CATEGORIAS");
            }
        }
}
