using SistemaWebPedidos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebPedidos.Core.Interfaces.Repositories
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
       Task<Pedido> ObterPorIdComItensPedidoEEndereco(int id, Guid userId);
        Task<Pedido> ObterPorIdComItensPedidoEEndereco(Guid id);
        Task<List<Pedido>> ObtberPedidoIdUsuario(Guid id);
       Task<List<Pedido>> GetAll(int skip, int take);
       Task<Pedido> EditStatus(Guid Id);
        Task<int> TotalPedidos();
       Task<int> TotalPedidosUsuarioId(Guid Id);
   

    }

}
