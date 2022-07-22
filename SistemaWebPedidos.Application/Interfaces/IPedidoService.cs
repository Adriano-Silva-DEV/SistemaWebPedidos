using SistemaWebPedidos.Application.ViewModels;
using SistemaWebPedidos.Application.ViewModels;
using SistemaWebPedidos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebPedidos.Application.Interfaces
{
    public interface IPedidoService
    {
        Task<PedidoViewModel> Processar(PedidoViewModel pedido, Guid userId);

       Task<PedidoViewModel> GetId(int Id, Guid userId);

        Task<List<PedidoViewModel>> GetUserId(Guid Id);

        Task<List<PedidoViewModel>> GetAll(int skip, int take);

        Task<int> TotalPedidos ();

        Task<int> TotalPedidosUsuarioId(Guid Id);

        Task<List<PedidoViewModel>> EditStatus(Guid Id);

         Task<PedidoViewModel> AtualizarStatus(string status, Guid id);

    }
}
