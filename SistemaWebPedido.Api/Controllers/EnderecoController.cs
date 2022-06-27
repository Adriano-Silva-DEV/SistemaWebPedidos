using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaWebPedidos.Application.Extensions;
using SistemaWebPedidos.Application.Interfaces;
using SistemaWebPedidos.Application.ViewModels;
using System;
using System.IO;
using System.Threading.Tasks;

namespace SistemaWebPedidos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : MainController
    {

        private readonly IMapper _mapper;

        private readonly IEnderecoService _enderecoService;

        public EnderecoController(IEnderecoService enderecoService, IMapper mapper, INotificador notificador, IUser appUser) : base(notificador, appUser)
        {
            _mapper = mapper;
            _enderecoService = enderecoService;
        }


        [Authorize]
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> ObterPorId ()
        {
          
            try
            {
                 var endereco= await _enderecoService.ObterPorId(_appUser.GetUserId());
                return  CustomResponse(endereco);
            }
            catch
            {
                NotificarErro("Ops! Ocorreu um erro");
                return CustomResponse();
            }
        }


    }
}
