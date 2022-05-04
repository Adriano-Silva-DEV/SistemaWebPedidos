using SistemaWebPedidos.Application.ViewModels;
using SistemaWebPedidos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebPedidos.Application.Interfaces
{
    public interface ICategoriaService
    {
        public  Task<CategoriaViewModel> BuscarPorId(Guid id);
        public  Task<CategoriaViewModel> Salvar(CategoriaViewModel categoriarViewModel);
        public Task<CategoriaViewModel> Atualizar(CategoriaViewModel categoriarViewModel);
        public Task<IEnumerable<CategoriaViewModel>> ListarTodos();
        public Task Remover(CategoriaViewModel categoriarViewModel); 

    }
}
