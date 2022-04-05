using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaWebPedidos.Application.Interfaces;
using SistemaWebPedidos.Application.Services;
using SistemaWebPedidos.Application.ViewModels;
using System.Threading.Tasks;

namespace SistemaWebPedidos.Api.Controllers
{    
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private IFornecedorService _fornecedorService;

        private readonly IMapper _mapper;

        public FornecedorController(IFornecedorService fornecedorService, IMapper mapper)
        {
            this._fornecedorService = fornecedorService;
            _mapper = mapper;
        }
       
        [Route("fornecedor/novo")]
        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] FornecedorViewModel fornecedorViewModel)
        {
            if (!ModelState.IsValid || fornecedorViewModel is null)
                  return BadRequest(ModelState);


            try
            {
                await _fornecedorService.Inserir(fornecedorViewModel);
                return Ok();
            }
            catch (System.Exception)
            {
                return BadRequest();
            } 
        }
    }
}
