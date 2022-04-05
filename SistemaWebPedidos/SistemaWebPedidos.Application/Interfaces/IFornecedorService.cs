using SistemaWebPedidos.Application.ViewModels;
using SistemaWebPedidos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebPedidos.Application.Interfaces
{
    public interface IFornecedorService
    {
        public  Task<FornecedorViewModel> BuscarPorId(Guid id);
        public  Task<FornecedorViewModel> Salvar(FornecedorViewModel fornecedorViewModel);
        public Task<IEnumerable<FornecedorViewModel>> ListarTodos();

        public Task Inserir(FornecedorViewModel fornecedorViewModel);

    }
}
