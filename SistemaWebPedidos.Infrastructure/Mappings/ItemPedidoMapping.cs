using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaWebPedidos.Core.Entities;

namespace SistemaWebPedidos.Infrastructure.Mappings
{
    public class ItemPedidoMapping : IEntityTypeConfiguration<ItemPedido>
        {
            public void Configure(EntityTypeBuilder<ItemPedido> builder)
            {
                builder.HasKey(p => p.Id);

            builder.HasOne(p => p.Produto)
                  .WithMany(f => f.ItemPedido)
                  .HasForeignKey(p => p.ProdutoId);
                  

            builder.HasOne(p => p.Pedido)
                        .WithMany(f => f.ItensPedido);
            }
        }
}
