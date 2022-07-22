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
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;

        private readonly IMapper _mapper;

        public EnderecoService(IEnderecoRepository enderecoRepository, IMapper mapper)
        {
            this._enderecoRepository = enderecoRepository;
            this._mapper = mapper;
        }

        public async Task<EnderecoViewModel> ObterPorId(Guid id)
        {
            return _mapper.Map<EnderecoViewModel>(await _enderecoRepository.ObterPorId(id));
        }

        public async Task<EnderecoViewModel> Editar(EnderecoViewModel endereco, Guid id)
        {
            var enderecoCliente = await _enderecoRepository.ObterPorId(id);
            endereco.Id = enderecoCliente.Id;

           await _enderecoRepository.Atualizar( _mapper.Map<Endereco>(endereco) );

            return endereco;
        }

    }
}
