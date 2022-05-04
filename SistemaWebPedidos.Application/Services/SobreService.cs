using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaWebPedidos.Application.Interfaces;
using SistemaWebPedidos.Application.ViewModels;
using SistemaWebPedidos.Core.Entities;
using SistemaWebPedidos.Core.Interfaces.Repositories;
using SistemaWebPedidos.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebPedidos.Application.Services
{
    public class SobreService : ISobreService
    {
        private readonly ISobreRepository  _sobreRepository;

        private readonly IMapper _mapper;

        public SobreService(ISobreRepository sobreRepository, IMapper mapper)
        {
            this._sobreRepository = sobreRepository;
            this._mapper = mapper;
        }


        public async Task<SobreViewModel> Listar()
        {
            return _mapper.Map<SobreViewModel>( await _sobreRepository.Obter());
        }

 
        public async Task<SobreViewModel> Atualizar(SobreViewModel sobreViewModel)
        {
            var sobre = _mapper.Map<Sobre>(sobreViewModel);
            await _sobreRepository.Atualizar(sobre);
            return sobreViewModel;
        }
    
    }
}
