using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaWebPedidos.Application.Extensions;
using SistemaWebPedidos.Application.Interfaces;
using SistemaWebPedidos.Application.ViewModels;
using System;
using System.Threading.Tasks;

namespace SistemaWebPedidos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService, IMapper mapper, INotificador notificador, IUser appUser) : base(notificador, appUser)
        {
            _mapper = mapper;
            _pedidoService = pedidoService;
        }

        [Authorize]
        [HttpPost]
        [Route("processar")]
        public async Task<IActionResult> Processar([FromBody] PedidoViewModel pedido)
        {

            try
            {
                var pedidoProcesado = await _pedidoService.Processar(pedido, _appUser.GetUserId());
                return CustomResponse(pedidoProcesado);
            }
            catch
            {
                NotificarErro("Ops! Ocorreu um erro");
                return CustomResponse();
            }
        }


        [Authorize]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            try
            {
                var pedidoProcesado = await _pedidoService.GetId(id, _appUser.GetUserId());
                return CustomResponse(pedidoProcesado);
            }
            catch
            {
                NotificarErro("Ops! Ocorreu um erro");
                return CustomResponse();
            }
        }

        [Authorize]
        [HttpGet]
        [Route("userId/{id}")]
        public async Task<IActionResult> GetUserId(Guid id)
        {

            try
            {
                var pedidoProcesado = await _pedidoService.GetUserId(_appUser.GetUserId()) ;
                return CustomResponse(pedidoProcesado);
            }
            catch
            {
                NotificarErro("Ops! Ocorreu um erro");
                return CustomResponse();
            }
        }

        [Authorize]
        [HttpPut]
        [Route("atualizar/status/{id}")]
        public async Task<IActionResult> GetUserId([FromBody]StatusPedidoViewModel status, Guid id)
        {

            try
            {
                var pedidoProcesado = await _pedidoService.AtualizarStatus(status.Nome, id);
                return CustomResponse(pedidoProcesado);
            }
            catch
            {
                NotificarErro("Ops! Ocorreu um erro");
                return CustomResponse();
            }
        }

        [ClaimsAuthorize("Fornecedor", "Remover")]
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Getall([FromQuery]int skip = 0, [FromQuery]int take = 5)
        {

            try {
                double total = await _pedidoService.TotalPedidos();

                var pagination = new Pagination (skip, take, (int) Math.Ceiling(total / take) );

                var pedidos = await _pedidoService.GetAll(skip,take);
                    pedidos.ForEach(p => p.Pagination = pagination ); 
                return CustomResponse(pedidos);
            }
            catch
            {
                NotificarErro("Ops! Ocorreu um erro");
                return CustomResponse();
            }
        }
    }

}
