using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaWebPedidos.Core.Entities;
using System;

namespace SistemaWebPedidos.Infrastructure.Mappings
{
    public class MeioPagamentoMapping : IEntityTypeConfiguration<MeioPagamento>
    {
        public void Configure(EntityTypeBuilder<MeioPagamento> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasMany(p => p.Pedido)
               .WithOne(c => c.MeioPagamento)
               .HasForeignKey(f => f.MeioPagamentoId);

            builder.ToTable("MEIO_PAGAMENTO");

            builder.HasData(
                new MeioPagamento
                { Id = new Guid("32abc88f-b734-404d-a23a-ff629ff69de7"),
                    Nome = "Dinheiro ou Pix",
                    Ativo = true,
                    NumMaxParcelamento = 1,
                    Img = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT7MsT24vvFA5FqSn2vhmwjR3IFKLKZvekhOg&usqp=CAU",
                    ValorMinParcela = 999999999
                },
                 new MeioPagamento
                 {   Id = new Guid("849dc3be-f82e-41b8-aec9-1afa806edc1d"),
                     Nome = "Cartão VISA",
                     Ativo = true,
                     NumMaxParcelamento = 10,
                     Img = "https://logosmarcas.net/wp-content/uploads/2020/09/MasterCard-Logo-1990-1996.png",
                     ValorMinParcela = 20
                 },
                  new MeioPagamento
                  {
                      Id = new Guid("21aaa660-be61-43be-ba31-08b044ac04c1"),
                      Nome = "Cartão Master",
                      Ativo = true,
                      NumMaxParcelamento = 6,
                      Img = "https://w7.pngwing.com/pngs/371/4/png-transparent-visa-debit-card-credit-card-logo-mastercard-visa-text-trademark-logo.png",
                      ValorMinParcela = 50
                  }
                ) ;         
        }
    }
}
