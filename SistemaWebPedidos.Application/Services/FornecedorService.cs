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

        public FornecedorService(IFornecedorRepository fornecedorRepository, IMapper mapper)
        {
            this._fornecedorRepository = fornecedorRepository;
            this._mapper = mapper;
        }

        public async Task<FornecedorViewModel> BuscarPorId(Guid id)
        {
            return  _mapper.Map<FornecedorViewModel>(await _fornecedorRepository.ObterPorId(id));
        }

        public async Task<IEnumerable<FornecedorViewModel>> ListarTodos()
        {
            return _mapper.Map<IEnumerable<FornecedorViewModel>>( await _fornecedorRepository.ObterTodos());
        }

        public async Task<FornecedorViewModel> Salvar(FornecedorViewModel fornecedorViewModel)
        {
            var fornecedor = _mapper.Map<Fornecedor>(fornecedorViewModel);
            return _mapper.Map<FornecedorViewModel>( await _fornecedorRepository.Adcionar(fornecedor));
           
        }

        public async Task<FornecedorViewModel> Atualizar(FornecedorViewModel fornecedorViewModel)
        {
            var fornecedor = _mapper.Map<Fornecedor>(fornecedorViewModel);
            await _fornecedorRepository.Atualizar(fornecedor);
            return fornecedorViewModel;
        }

        public async Task Remover(FornecedorViewModel fornecedorViewModel)
        {
            await _fornecedorRepository.Remover(fornecedorViewModel.Id);
        }

        public async Task<FornecedorViewModel> obterPorDocumento(string documento)
        {
            Fornecedor fornecedor = await _fornecedorRepository.obterPorDocumento(documento);

            if (fornecedor is null) return null;

           return _mapper.Map<FornecedorViewModel>(fornecedor);
        }
    }
}
