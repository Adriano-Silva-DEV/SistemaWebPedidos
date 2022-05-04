using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaWebPedidos.Core.Entities;

namespace SistemaWebPedidos.Infrastructure.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.HasOne(p => p.Endereco)
                .WithOne(f => f.Usuario);

            builder.ToTable("USUARIOS");
        }
    }
}
