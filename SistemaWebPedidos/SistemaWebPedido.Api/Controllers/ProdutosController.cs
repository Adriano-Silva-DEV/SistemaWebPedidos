using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaWebPedidos.Application.Interfaces;

namespace SistemaWebPedidos.Api.Controllers
{
    public class ProdutosController : MainController
    {
        private readonly IMapper _mapper;

        public ProdutosController(IMapper mapper, INotificador notificador, IUser appUser) : base(notificador, appUser)
        {
            _mapper = mapper;
        }

    }
}
