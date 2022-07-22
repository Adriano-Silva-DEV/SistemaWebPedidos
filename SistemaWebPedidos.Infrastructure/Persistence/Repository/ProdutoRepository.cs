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
            return await _apiDbContext.Produtos.AsNoTracking().Where(p => p.Excluido == false). FirstOrDefaultAsync(f => f.Sku == sku);
        }

        public async Task<IEnumerable<Produto>> ObterComCategoria(int skip, int take)
        {
            return await _apiDbContext.Produtos.AsNoTracking().OrderByDescending(p => p.dataCadastro).Where(p => p.Excluido == false).Skip(skip).Take(take).Include(p => p.Categoria).Include(f => f.Fornecedor).ToListAsync();
        }

        public async Task<Produto> ObterPorIdComCategoriaEFornecedor(Guid id)
        {
            return await _apiDbContext.Produtos.AsNoTracking().Where(p => p.Excluido == false).Include(p => p.Categoria).Include(f => f.Fornecedor).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Produto>> Busca(string id)
        {
            return await _apiDbContext.Produtos.AsNoTracking().Where(p => p.Excluido == false).Include(p => p.Categoria).Include(f => f.Fornecedor).Where(p => p.Nome.ToUpper().Contains(id.ToUpper())
            || p.Descricao.ToUpper().Contains(id.ToUpper())).ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterPorFornecedor(Guid id)
        {
            return await _apiDbContext.Produtos.AsNoTracking().Where(p => p.Excluido == false).Include(p => p.Categoria).Include(f => f.Fornecedor).Where(p => p.FornecedorId == id).ToListAsync();
        }

        public async Task<IEnumerable<Produto>> ObterPorCategoria(Guid id)
        {
            return await _apiDbContext.Produtos.AsNoTracking().Where(p => p.Excluido == false).Include(p => p.Categoria).Include(f => f.Fornecedor).Where(p => p.CategoriaId == id).ToListAsync();

        }
        public async Task<IEnumerable<Produto>> obterPorCategoria(Guid categoria)
        {
            return await _apiDbContext.Produtos.AsNoTracking().Where(p => p.Excluido == false).Include(p => p.Categoria).Where(e => e.CategoriaId == categoria).ToListAsync();
        }

        public async Task<int> TotalPedidos()
        {
            return await _apiDbContext.Produtos.AsNoTracking().Where(p => p.Excluido == false).CountAsync();
        }

    }
   
}

