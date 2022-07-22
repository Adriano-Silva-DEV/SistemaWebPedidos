using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaWebPedidos.Core.Entities;

namespace SistemaWebPedidos.Infrastructure.Mappings
{
    public class PedidoMapping : IEntityTypeConfiguration<Pedido>
        {
            public void Configure(EntityTypeBuilder<Pedido> builder)
            {
                builder.HasKey(p => p.Id);

            builder.Property(p => p.NumeroPedido)
                  .ValueGeneratedOnAdd();
                

            builder.HasOne(p => p.MeioPagamento)
                          .WithMany(f => f.Pedido);

            builder.HasMany(p => p.ItensPedido)
             .WithOne(f => f.Pedido)
         .HasForeignKey(p => p.PedidoId);

            builder.ToTable("PEDIDOS");
            }
        }
}
