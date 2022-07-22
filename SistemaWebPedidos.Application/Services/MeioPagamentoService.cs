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
    public class MeioPagamentoService : Interfaces.IMeioPagamentoService
    {
        private readonly Core.Interfaces.Repositories.IMeioPagamentoService _meioPagamentoRepository;

        private readonly IMapper _mapper;

        public MeioPagamentoService(Core.Interfaces.Repositories.IMeioPagamentoService meioPagamentoRepository, IMapper mapper)
        {
            this._meioPagamentoRepository = meioPagamentoRepository;
            this._mapper = mapper;
        }

       
        public async Task<IEnumerable<MeioPagamentoViewModel>> ListarTodos()
        {
            return _mapper.Map<IEnumerable<MeioPagamentoViewModel>>( await _meioPagamentoRepository.ObterTodos());
        }
    }
}
