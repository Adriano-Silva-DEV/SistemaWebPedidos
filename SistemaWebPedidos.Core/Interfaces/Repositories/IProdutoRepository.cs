using SistemaWebPedidos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebPedidos.Core.Interfaces.Repositories
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<Produto> ObterPorSku(String sku);
        Task<IEnumerable<Produto>> ObterComCategoria();
        Task<IEnumerable<Produto>> obterPorCategoria(Guid categoria);
        Task<Produto> ObterPorIdComCategoriaEFornecedor(Guid id);
        Task<IEnumerable<Produto>> Busca(string id);
        Task<IEnumerable<Produto>> ObterPorFornecedor(Guid id);

        Task<IEnumerable<Produto>> ObterPorCategoria(Guid id);


    }
}
