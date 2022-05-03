using SistemaWebPedidos.Application.ViewModels;
using SistemaWebPedidos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebPedidos.Application.Interfaces
{
    public interface IUsuarioService
    {
        public  Task<UsuarioViewModel> Salvar(UsuarioViewModel usuarioViewModel);
        public Task<UsuarioViewModel> Atualizar(UsuarioViewModel usuarioViewModel);

        public Task<List<UsuarioViewModel>> Listar();

        public Task<UsuarioViewModel> ObterPorId(Guid id);

        public Task<UsuarioViewModel> ObterPorIdIdentity(Guid id);

    }
}
