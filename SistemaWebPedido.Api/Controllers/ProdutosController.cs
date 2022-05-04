﻿using AutoMapper;
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
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : MainController
    {
        private readonly IMapper _mapper;

        private readonly IProdutoService _produtoService;

        public ProdutosController(IProdutoService produtoService, IMapper mapper, INotificador notificador, IUser appUser) : base(notificador, appUser)
        {
            _mapper = mapper;
            _produtoService = produtoService;
        }

        [AllowAnonymous]
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> listar()
        {

            try
            {
                return CustomResponse(await _produtoService.ListarTodos());
            }
            catch
            {
                NotificarErro("Ops! Ocorreu um erro");
                return CustomResponse();
            }
        }

        [ClaimsAuthorize("Produto", "Salvar")]
        [Route("salvar")]
        [HttpPost]
        public async Task<IActionResult> Salvar([FromBody] ProdutoViewModel produtoViewModel)
        {
            if (!ModelState.IsValid || produtoViewModel is null)
                return BadRequest(ModelState);


            var imagemNome = Guid.NewGuid() + "_" + produtoViewModel.Imagem1;
            if (!UploadArquivo(produtoViewModel.ImagemUpload, imagemNome))
            {
                return CustomResponse(produtoViewModel);
            }

            produtoViewModel.Imagem1 = imagemNome;

            try
            {
                //  var produto = await _produtoService.ObterPorSku(produtoViewModel.Sku);
                //  if (produto is not null)
                //  {
                //      NotificarErro("Ops! Já existe um  produto com este Sku");
                //      return CustomResponse();
                //  }


                var resultSave = await _produtoService.Salvar(produtoViewModel);

                return CustomResponse(resultSave);
            }
            catch (System.Exception)
            {
                NotificarErro("Ops! Ocorreu um erro");
                return CustomResponse();
            }
        }

        [ClaimsAuthorize("Produto", "Atualizar")]
        [Route("atualizar/{id:guid}")]
        [HttpPut]
        public async Task<IActionResult> Atualizar([FromBody] ProdutoViewModel produtoViewModel, Guid id)
        {
            if (!ModelState.IsValid || produtoViewModel is null)
                return BadRequest(ModelState);

            if (produtoViewModel.ImagemUpload is not null)
            {
                var imagemNome = Guid.NewGuid() + "_" + produtoViewModel.Imagem1;

                if (!UploadArquivo(produtoViewModel.ImagemUpload, imagemNome))
                {
                    return CustomResponse(produtoViewModel);
                }
                produtoViewModel.Imagem1 = imagemNome;
            }


            try
            {
                var produto = await _produtoService.BuscarPorId(id);
                if (produto is null) return NotFound();

                produtoViewModel.Id = id;

                await _produtoService.Atualizar(produtoViewModel);

                return CustomResponse(produtoViewModel);
            }
            catch (System.Exception)
            {
                NotificarErro("Ops! Ocorreu um erro");
                return CustomResponse();
            }
        }

        [AllowAnonymous]
        [Route("{id:guid}")]
        [HttpGet]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var produtoViewModel = await _produtoService.BuscarPorId(id);

            if (produtoViewModel is null) return NotFound();

            return CustomResponse(produtoViewModel);
        }

        [AllowAnonymous]
        [Route("{id:guid}/fornecedor")]
        [HttpGet]
        public async Task<IActionResult> ObterPorFornecedor(Guid id)
        {
            var produtoViewModel = await _produtoService.ObterPorFornecedor(id);

            if (produtoViewModel is null) return NotFound();

            return CustomResponse(produtoViewModel);
        }

        [AllowAnonymous]
        [Route("{id:guid}/categoria")]
        [HttpGet]
        public async Task<IActionResult> ObterPorCategoria(Guid id)
        {
            var produtoViewModel = await _produtoService.ObterPorCategoria(id);

            if (produtoViewModel is null) return NotFound();

            return CustomResponse(produtoViewModel);
        }

        [ClaimsAuthorize("Produto", "Remover")]
        [Route("remover/{id:guid}")]
        [HttpDelete]
        public async Task<IActionResult> Remover(Guid id)
        {
            var produtoViewModel = await _produtoService.BuscarPorId(id);

            if (produtoViewModel is null) return NotFound();

            await _produtoService.Remover(produtoViewModel);

            return CustomResponse(produtoViewModel);
        }


        private bool UploadArquivo(string arquivo, string imgNome)
        {
            if (string.IsNullOrEmpty(arquivo))
            {
                NotificarErro("Forneça uma imagem para este produto!");
                return false;
            }

            var imageDataByteArray = Convert.FromBase64String(arquivo);

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imgs", imgNome);

            if (System.IO.File.Exists(filePath))
            {
                NotificarErro("Já existe um arquivo com este nome!");
                return false;
            }

            System.IO.File.WriteAllBytes(filePath, imageDataByteArray);

            return true;
        }

    }
}
