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
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository  _produtoRepository;

        private readonly IMapper _mapper;

        public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper)
        {
            this._produtoRepository = produtoRepository;
            this._mapper = mapper;
        }

        public async Task<ProdutoViewModel> BuscarPorId(Guid id)
        {
            return  _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterPorId(id));
        }

        public async Task<IEnumerable<ProdutoViewModel>> ListarTodos()
        {
            return _mapper.Map<IEnumerable<ProdutoViewModel>>( await _produtoRepository.ObterComCategoria());
        }

        public async Task<ProdutoViewModel> Salvar(ProdutoViewModel produtoViewModel)
        {
            var produto = _mapper.Map<Produto>(produtoViewModel);
            return _mapper.Map<ProdutoViewModel>( await _produtoRepository.Adcionar(produto));
           
        }

        public async Task<ProdutoViewModel> Atualizar(ProdutoViewModel produtoViewModel)
        {
            var produto = _mapper.Map<Produto>(produtoViewModel);
            await _produtoRepository.Atualizar(produto);
            return produtoViewModel;
        }

        public async Task Remover(ProdutoViewModel produtoViewModel)
        {
            await _produtoRepository.Remover(produtoViewModel.Id);
        }

        public async Task<ProdutoViewModel> ObterPorSku(string sku)
        {
            return _mapper.Map<ProdutoViewModel>(await _produtoRepository.ObterPorSku(sku));
        }
    }
}
