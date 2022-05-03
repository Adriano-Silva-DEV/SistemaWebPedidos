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
    public class CategoriasController : MainController
    {
        private ICategoriaService _categoriaService;
        private readonly IMapper _mapper;


        public CategoriasController(ICategoriaService categoriaService, IMapper mapper, INotificador notificador, IUser appUser) : base(notificador, appUser)
        {
            this._categoriaService = categoriaService;
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
                return CustomResponse(await _categoriaService.ListarTodos());
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
        public async Task<IActionResult> Salvar([FromBody] CategoriaViewModel categoriaViewModel)
        {
            if (!ModelState.IsValid || categoriaViewModel is null)
                return BadRequest(ModelState);


            try
            {
                var resultSave = await _categoriaService.Salvar(categoriaViewModel);

                return CustomResponse(resultSave);
            }
            catch (System.Exception)
            {
                NotificarErro("Ops! Ocorreu um erro");
                return CustomResponse(categoriaViewModel);
            }
        }

        [ClaimsAuthorize("Fornecedor", "Atualizar")]
        [Route("atualizar/{id:guid}")]
        [HttpPut]
        public async Task<IActionResult> Atualizar([FromBody] CategoriaViewModel categoriaViewModel, Guid id)
        {
            if (!ModelState.IsValid || categoriaViewModel is null)
                return BadRequest(ModelState);


            try
            {
                var categoria = await _categoriaService.BuscarPorId(id);
                if (categoria is null) return NotFound();

                categoriaViewModel.Id = id;

                await _categoriaService.Atualizar(categoriaViewModel);

                return CustomResponse(categoriaViewModel);
            }
            catch (System.Exception)
            {
                NotificarErro("Ops! Ocorreu um erro");
                return CustomResponse();
            }
        }

        [ClaimsAuthorize("Fornecedor", "Listar")]
        [Route("{id:guid}")]
        [HttpGet]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var categoriaViewModel = await _categoriaService.BuscarPorId(id);

            if (categoriaViewModel is null) return NotFound();

            return CustomResponse(categoriaViewModel);
        }

        [ClaimsAuthorize("Fornecedor", "Remover")]
        [Route("remover/{id:guid}")]
        [HttpDelete]
        public async Task<IActionResult> Remover(Guid id)
        {
            var categoriaViewModel = await _categoriaService.BuscarPorId(id);

            if (categoriaViewModel is null) return NotFound();

            if (categoriaViewModel.Produtos.Count > 0)
            {
                NotificarErro("Ops! Existe produtos vinculados a esta categoria");
                return CustomResponse(id);
            }

            await _categoriaService.Remover(categoriaViewModel);

            return CustomResponse(categoriaViewModel);
        }
    }
}
