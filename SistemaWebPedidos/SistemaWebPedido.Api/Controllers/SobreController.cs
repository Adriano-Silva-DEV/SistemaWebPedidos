using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaWebPedidos.Application.Extensions;
using SistemaWebPedidos.Application.Interfaces;
using SistemaWebPedidos.Application.ViewModels;
using System.Threading.Tasks;

namespace SistemaWebPedidos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SobreController : MainController
    {

        private readonly IMapper _mapper;

        private readonly ISobreService _sobreService;

        public SobreController(ISobreService sobreService, IMapper mapper, INotificador notificador, IUser appUser) : base(notificador, appUser)
        {
            _mapper = mapper;
            _sobreService = sobreService;
        }


        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Listar ()
        {
            try
            {
                return CustomResponse( await _sobreService.Listar());
            }
            catch
            {
                NotificarErro("Ops! Ocorreu um erro");
                return CustomResponse();
            }
        }

        [ClaimsAuthorize("Sobre", "Salvar")]
        [Route("/salvar")]
        [HttpGet]
        public async Task<IActionResult> Salvar(SobreViewModel sobreViewModel )
        {
            if (!ModelState.IsValid || sobreViewModel is null) return CustomResponse(ModelState);

            try
            {
                var sobre = await _sobreService.Listar();

                if (sobre is null)
                {
                    NotificarErro("Ops! Ocorreu um erro");
                    return CustomResponse();
                }
                sobreViewModel.Id = sobre.Id;

                return CustomResponse(await _sobreService.Salvar(sobreViewModel));
            }
            catch
            {
                NotificarErro("Ops! Ocorreu um erro");
                return CustomResponse();
            }
        }
    }
}
