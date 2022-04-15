using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaWebPedidos.Application.Interfaces;

namespace SistemaWebPedidos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SobreController : MainController
    {

        private readonly IMapper _mapper;

        public SobreController(IMapper mapper, INotificador notificador, IUser appUser) : base(notificador, appUser)
        {
            _mapper = mapper;
        }



    }
}
