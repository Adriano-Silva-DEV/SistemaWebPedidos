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
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepository  _fornecedorRepository;

        private readonly IMapper _mapper;

        public FornecedorService(IFornecedorRepository produtoRepository, IMapper mapper)
        {
            this._fornecedorRepository = produtoRepository;
            this._mapper = mapper;
        }

        public async Task Inserir(FornecedorViewModel fornecedorViewModel)
        {
            var fornecedor = _mapper.Map<Fornecedor>(fornecedorViewModel);
           await _fornecedorRepository.Adcionar(fornecedor);


        }

        public Task<FornecedorViewModel> BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<FornecedorViewModel>> ListarTodos()
        {
            return _mapper.Map<IEnumerable<FornecedorViewModel>>( await _fornecedorRepository.ObterTodos());
        }

        public Task<FornecedorViewModel> Salvar(FornecedorViewModel fornecedorViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
