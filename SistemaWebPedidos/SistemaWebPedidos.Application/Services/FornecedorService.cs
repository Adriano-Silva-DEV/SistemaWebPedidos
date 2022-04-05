using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaWebPedidos.Application.Interfaces;
using SistemaWebPedidos.Application.ViewModels;
using SistemaWebPedidos.Core.Entities;
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
        private readonly ApiDbContext _apiDbContext;

        private readonly IMapper _mapper;

        public FornecedorService(ApiDbContext apiDbContext, IMapper mapper)
        {
            this._apiDbContext = apiDbContext;
            this._mapper = mapper;
        }

        public async Task Inserir(FornecedorViewModel fornecedorViewModel)
        {
            var fornecedor = _mapper.Map<Fornecedor>(fornecedorViewModel);
           _apiDbContext.Add(fornecedor);

            await _apiDbContext.SaveChangesAsync();

        }

        public Task<FornecedorViewModel> BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<FornecedorViewModel>> ListarTodos()
        {
            return _mapper.Map<IEnumerable<FornecedorViewModel>>( await _apiDbContext.Fornecedores.ToListAsync());
        }

        public Task<FornecedorViewModel> Salvar(FornecedorViewModel fornecedorViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
