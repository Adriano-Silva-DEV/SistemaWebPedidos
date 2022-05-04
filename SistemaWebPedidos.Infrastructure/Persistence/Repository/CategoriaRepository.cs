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
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(ApiDbContext apiDbContext) : base(apiDbContext)
        {

        }

        public async Task<IEnumerable<Categoria>> ObterComProdutos()
        {
            return await _apiDbContext.Categorias.AsNoTracking().Include(p => p.Produtos).ToListAsync();
        }

    }
}
