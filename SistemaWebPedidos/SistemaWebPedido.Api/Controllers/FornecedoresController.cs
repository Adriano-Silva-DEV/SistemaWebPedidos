using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaWebPedidos.Application.Extensions;
using SistemaWebPedidos.Application.Interfaces;
using SistemaWebPedidos.Application.Services;
using SistemaWebPedidos.Application.ViewModels;
using System;
using System.Threading.Tasks;

namespace SistemaWebPedidos.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedoresController : MainController
    {
        private IFornecedorService _fornecedorService;
        private readonly IMapper _mapper;


        public FornecedoresController(IFornecedorService fornecedorService, IMapper mapper, INotificador notificador, IUser appUser) : base(notificador, appUser)
        {
            this._fornecedorService = fornecedorService;
            _mapper = mapper;
        }

        [ClaimsAuthorize("Fornecedor", "Listar")]
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> listar()
        {
            var x =  _appUser.GetUserEmail();
            try
            {
                return CustomResponse(await _fornecedorService.ListarTodos());
            }
            catch
            {
                NotificarErro("Ops! Ocorreu um erro");
                return CustomResponse();
            }
        }

        [ClaimsAuthorize("Fornecedor", "Salvar")]
        [Route("salvar")]
        [HttpPost]
        public async Task<IActionResult> Salvar([FromBody] FornecedorViewModel fornecedorViewModel)
        {
            if (!ModelState.IsValid || fornecedorViewModel is null)
                return BadRequest(ModelState);


            try
            {
                var fornecedor = await _fornecedorService.obterPorDocumento(fornecedorViewModel.Documento);
               if (fornecedor is not null)
                {
                    NotificarErro("Ops! Já existe um fornecedor com este documento");
                    return CustomResponse();
                }


                var resultSave = await _fornecedorService.Salvar(fornecedorViewModel);

                return CustomResponse(resultSave);
            }
            catch (System.Exception)
            {
                NotificarErro("Ops! Ocorreu um erro");
                return CustomResponse();
            }
        }

        [ClaimsAuthorize("Fornecedor", "Atualizar")]
        [Route("atualizar/{id:guid}")]
        [HttpPut]
        public async Task<IActionResult> Atualizar([FromBody] FornecedorViewModel fornecedorViewModel, Guid id)
        {
            if (!ModelState.IsValid || fornecedorViewModel is null)
                return BadRequest(ModelState);


            try
            {
                var fornecedor = await _fornecedorService.BuscarPorId(id);
                if (fornecedorViewModel is null) return NotFound();

                fornecedorViewModel.Id = id;

                await _fornecedorService.Atualizar(fornecedorViewModel);

                return CustomResponse(fornecedorViewModel);
            }
            catch (System.Exception)
            {
                NotificarErro("Ops! Ocorreu um erro");
                return CustomResponse();
            }
        }

        [ClaimsAuthorize("Fornecedor", "Listar")]
        [Route("{id:guid}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var fornecedorViewModel = await _fornecedorService.BuscarPorId(id);

            if (fornecedorViewModel is null) return NotFound();

            return CustomResponse(fornecedorViewModel);
        }

        [ClaimsAuthorize("Fornecedor", "Remover")]
        [Route("remover/{id:guid}")]
        public async Task<IActionResult> Remover(Guid id)
        {
            var fornecedorViewModel = await _fornecedorService.BuscarPorId(id);

            if (fornecedorViewModel is null) return NotFound();

            await _fornecedorService.Remover(fornecedorViewModel);

            return CustomResponse(fornecedorViewModel);
        }
    }
}
