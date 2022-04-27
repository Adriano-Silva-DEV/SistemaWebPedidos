using SistemaWebPedidos.Application.ViewModels;
using SistemaWebPedidos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebPedidos.Application.Interfaces
{
    public interface ISobreService
    {
        public  Task<SobreViewModel> Salvar(SobreViewModel sobreViewModel);
        public Task<SobreViewModel> Atualizar(SobreViewModel sobreViewModel);
        public Task<SobreViewModel> Listar();

    }
}
