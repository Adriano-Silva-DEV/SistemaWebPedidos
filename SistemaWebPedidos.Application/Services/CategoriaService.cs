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
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository  _categoriaRepository;
        private readonly IProdutoRepository _produtoRepository;

        private readonly IMapper _mapper;

        public CategoriaService(ICategoriaRepository categoriaRepository, IProdutoRepository produtoRepository, IMapper mapper)
        {
            this._categoriaRepository = categoriaRepository;
            this._mapper = mapper;
            this._produtoRepository = produtoRepository;
        }

        public async Task<CategoriaViewModel> BuscarPorId(Guid id)
        {
            var categoria = await _categoriaRepository.ObterPorId(id);
        
            var categoriaModel = _mapper.Map<CategoriaViewModel>(categoria);
            categoriaModel.Produtos = _mapper.Map<List<ProdutoViewModel>>(await _produtoRepository.obterPorCategoria(categoria.Id));
            return categoriaModel;
        }

        public async Task<IEnumerable<CategoriaViewModel>> ListarTodos()
        {
            return _mapper.Map<IEnumerable<CategoriaViewModel>>( await _categoriaRepository.ObterTodos());
        }

        public async Task<CategoriaViewModel> Salvar(CategoriaViewModel categoriaViewModel)
        {
            var categoria = _mapper.Map<Categoria>(categoriaViewModel);
            return _mapper.Map<CategoriaViewModel>( await _categoriaRepository.Adcionar(categoria));
           
        }

        public async Task<CategoriaViewModel> Atualizar(CategoriaViewModel categoriaViewModel)
        {
            var fornecedor = _mapper.Map<Categoria>(categoriaViewModel);
            await _categoriaRepository.Atualizar(fornecedor);
            return categoriaViewModel;
        }

        public async Task Remover(CategoriaViewModel categoriaViewModel)
        {
            await _categoriaRepository.Remover(categoriaViewModel.Id);
        }

    }
}
