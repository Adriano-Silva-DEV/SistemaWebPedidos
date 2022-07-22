using Microsoft.EntityFrameworkCore;
using SistemaWebPedidos.Core.Entities;
using SistemaWebPedidos.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebPedidos.Infrastructure.Persistence.Repository
{
    public class ItemPedidoRepository : Repository<ItemPedido>, IItemPedidoRepository
    {
        public ItemPedidoRepository(ApiDbContext apiDbContext) : base(apiDbContext)
        {

        }
        public async Task<List<ItemPedido>> ObterPorIdPedido(Guid id)
        {
            return await _apiDbContext.ItensPedidos.AsNoTracking().Where(p => p.PedidoId == id).ToListAsync();
           
        }

       
    }
}
