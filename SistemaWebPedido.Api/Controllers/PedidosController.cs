using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaWebPedidos.Application.Interfaces;

namespace SistemaWebPedidos.Api.Controllers
{
    public class PedidosController : MainController
    {
        private readonly IMapper _mapper;

        public PedidosController(IMapper mapper, INotificador notificador, IUser appUser) : base(notificador, appUser)
        {
            _mapper = mapper;
        }
    }
}
