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
    public class PedidoService : IPedidoService
    {
   

        private readonly IMapper _mapper;

        private readonly IPedidoRepository _pedidoRepository;

        private readonly IEnderecoService _enderecoService;

        private readonly IProdutoRepository _produtoRepository;

        public PedidoService(IProdutoRepository produdoRepository, IEnderecoService enderecoService, IMapper mapper, IPedidoRepository pedidoRepository)
        {
            _mapper = mapper;
            _pedidoRepository = pedidoRepository;
            _enderecoService = enderecoService;
            _produtoRepository = produdoRepository;
        }

      public  async Task<PedidoViewModel>  Processar(PedidoViewModel pedido, Guid userId)
        {
          pedido.EnderecoEntregaId =  (await _enderecoService.ObterPorId(userId)).Id;           
          pedido.UsuarioId = userId;
          pedido.DataCriacao = DateTime.Now;
            pedido.Status = "Em processamento";


           foreach ( var item in pedido.ItensPedido ){
              var produto = await _produtoRepository.ObterPorId(item.ProdutoId);
               pedido.ValorTotal = pedido.ValorTotal + ( item.Quantidade * produto.PrecoVenda);
            }


            Pedido result = await _pedidoRepository.Adcionar(_mapper.Map<Pedido>(pedido));
                

            return _mapper.Map<PedidoViewModel>(result);
        }

        public async Task<PedidoViewModel> AtualizarStatus(string status, Guid id)
        {
            var pedido = await _pedidoRepository.ObterPorIdComItensPedidoEEndereco(id);
            pedido.Status = status;

            await _pedidoRepository.Atualizar(pedido);

            return _mapper.Map<PedidoViewModel>(pedido);

        }

        public  async Task<PedidoViewModel> GetId(int id, Guid userId)
        {
   
           Pedido result = await _pedidoRepository.ObterPorIdComItensPedidoEEndereco(id,userId);
            
            return _mapper.Map<PedidoViewModel>(result);
        }

        public async Task<PedidoViewModel> GetId(int id)
        {

            Pedido result = await _pedidoRepository.ObterPorIdComItensPedidoEEndereco(id);

            return _mapper.Map<PedidoViewModel>(result);
        }


        public async Task<List<PedidoViewModel>> GetUserId(Guid id)
        {

            List<Pedido> result = await _pedidoRepository.ObtberPedidoIdUsuario
                (id);

            return _mapper.Map<List<PedidoViewModel>>(result);
        }

        public async Task<List<PedidoViewModel>> GetAll(int skip, int take)
        {

            List<Pedido> result = await _pedidoRepository.GetAll(skip, take);

            return _mapper.Map<List<PedidoViewModel>>(result);
        }

        public async Task<int> TotalPedidos()
        {
           return await _pedidoRepository.TotalPedidos();
        }

        public async Task<int> TotalPedidosUsuarioId(Guid id)
        {
           return  await _pedidoRepository.TotalPedidosUsuarioId(id);
        }

        public async Task<List<PedidoViewModel>> EditStatus(Guid Id)
        {
            return null;
        }
    }
}