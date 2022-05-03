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

        public async Task<Produto> ObterPorSku(string sku)
        {
            return await _apiDbContext.Produtos.AsNoTracking().FirstOrDefaultAsync(f => f.Sku == sku);
        }

        public async Task<IEnumerable<Produto>> ObterComCategoria()
        {
            return await _apiDbContext.Produtos.AsNoTracking().Include(p => p.Categoria).Include(f => f.Fornecedor).ToListAsync();
        }

        public async Task<Produto> ObterPorIdComCategoriaEFornecedor(Guid id)
        {
            return await _apiDbContext.Produtos.AsNoTracking().Include(p => p.Categoria).Include(f => f.Fornecedor).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Produto>> ObterPorFornecedor(Guid id)
        {
            return await _apiDbContext.Produtos.AsNoTracking().Include(p => p.Categoria).Include(f => f.Fornecedor).Where(p => p.FornecedorId == id).ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterPorCategoria(Guid id)
        {
            return await _apiDbContext.Produtos.AsNoTracking().Include(p => p.Categoria).Include(f => f.Fornecedor).Where(p => p.CategoriaId == id).ToListAsync();

        }
        public async Task<IEnumerable<Produto>> obterPorCategoria(Guid categoria)
        {
            return await _apiDbContext.Produtos.AsNoTracking().Include(p => p.Categoria).Where(e => e.CategoriaId == categoria).ToListAsync();
        }
    }
   
}

