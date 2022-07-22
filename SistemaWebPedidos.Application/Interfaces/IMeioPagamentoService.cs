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
    public interface IMeioPagamentoService
    {
        public Task<IEnumerable<MeioPagamentoViewModel>> ListarTodos();

    }
}
