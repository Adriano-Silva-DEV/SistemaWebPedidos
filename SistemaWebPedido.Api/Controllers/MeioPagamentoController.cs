using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaWebPedidos.Application.Interfaces;
using SistemaWebPedidos.Core.Interfaces.Repositories;
using System.Threading.Tasks;
using IMeioPagamentoService = SistemaWebPedidos.Core.Interfaces.Repositories.IMeioPagamentoService;

namespace SistemaWebPedidos.Api.Controllers
{
    [Route("api/MeioPagamento")]
    [ApiController]
    public class MeioPagamentoController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IMeioPagamentoService _meioPagamentoService;

        public MeioPagamentoController(IMeioPagamentoService meioPagamentoService, IMapper mapper, INotificador notificador, IUser appUser) : base(notificador, appUser)
        {
            _mapper = mapper;
            _meioPagamentoService = meioPagamentoService;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> ListarTodos()
        {

            try
            {
                var meioPagamento = await _meioPagamentoService.ObterTodos();
                return CustomResponse(meioPagamento);
            }
            catch
            {
                NotificarErro("Ops! Ocorreu um erro");
                return CustomResponse();
            }
        }
    }

}

