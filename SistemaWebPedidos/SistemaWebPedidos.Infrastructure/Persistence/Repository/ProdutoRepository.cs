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
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ApiDbContext apiDbContext) : base(apiDbContext)
        {

        }

        public async Task<Produto> ObterProdutoFornecedor(Guid id)
        {
            return await _apiDbContext.Produtos.AsNoTracking().Include(d => d.Fornecedor)
                 .FirstOrDefaultAsync(prop => prop.Id == id);
        }

        public async Task<IEnumerable<Produto>> ObterProdutosFornecedor()
        {
            return await _apiDbContext.Produtos.AsNoTracking()
               .OrderBy(p => p.Sku).ToListAsync();
        }
    }
}
