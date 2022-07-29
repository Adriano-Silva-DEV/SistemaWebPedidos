using Microsoft.EntityFrameworkCore;
using SistemaWebPedidos.Core.Entities;
using SistemaWebPedidos.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebPedidos.Infrastructure.Persistence.Repository
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(ApiDbContext apiDbContext) : base(apiDbContext)
        {

        }
        public async Task<Pedido> ObterPorIdComItensPedidoEEndereco(int id, Guid userId)
        {
            return await _apiDbContext.Pedidos.AsNoTracking().
                Include("ItensPedido.Produto").
                Include(f => f.EnderecoEntrega).
                Include(f => f.MeioPagamento).
                FirstOrDefaultAsync(p => p.NumeroPedido == id && p.UsuarioId == userId);
        }

        public async Task<Pedido> ObterPorIdComItensPedidoEEndereco(int id)
        {
            return await _apiDbContext.Pedidos.AsNoTracking().
                Include("ItensPedido.Produto").
                Include(f => f.EnderecoEntrega).
                Include(f => f.MeioPagamento).
                FirstOrDefaultAsync(p => p.NumeroPedido == id);
        }
        public async Task<Pedido> ObterPorIdComItensPedidoEEndereco(Guid id)
        {
            return await _apiDbContext.Pedidos.AsNoTracking().
                Include("ItensPedido.Produto").
                Include(f => f.EnderecoEntrega).
                Include(f => f.MeioPagamento).
                FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Pedido>> ObtberPedidoIdUsuario(Guid id){
            return await _apiDbContext.Pedidos.AsNoTracking().OrderByDescending(p => p.DataCriacao).
               Where(p => p.UsuarioId == id).ToListAsync();
          }

        public async Task<List<Pedido>> GetAll(int skip, int take)
        {
            return await _apiDbContext.Pedidos.AsNoTracking().OrderByDescending(p => p.DataCriacao).Skip(skip).Take(take)
                .ToListAsync();
        }

        public async Task<int> TotalPedidos()
        {
            return await _apiDbContext.Pedidos.AsNoTracking().CountAsync();
        }
        public async Task<int> TotalPedidosUsuarioId(Guid id)
        {
            return await _apiDbContext.Pedidos.AsNoTracking().Where(ped => ped.UsuarioId == id).CountAsync();
        }

        public Task<Pedido> EditStatus(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
