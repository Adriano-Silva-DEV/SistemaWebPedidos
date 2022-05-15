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
        [Route("")]
        public async Task<IActionResult> Listar ()
        {
            try
            {
                 var returnr = await _sobreService.Listar();
                return  CustomResponse(returnr);
            }
            catch
            {
                NotificarErro("Ops! Ocorreu um erro");
                return CustomResponse();
            }
        }

        [ClaimsAuthorize("Produto", "Salvar")]
        [Route("salvar")]
        [HttpPut]
        public async Task<IActionResult> Salvar([FromBody] SobreViewModel sobreViewModel )
        {
            if (!ModelState.IsValid || sobreViewModel is null) return CustomResponse(ModelState);


            var imagemNome = Guid.NewGuid() + "_" + sobreViewModel.Imagem1;
            if (!UploadArquivo(sobreViewModel.ImagemUpload, imagemNome))
            {
                return CustomResponse(sobreViewModel);
            }

            sobreViewModel.Imagem1 = imagemNome;

            try
            {
                var sobre = await _sobreService.Listar();

                if (sobre is null)
                {
                    NotificarErro("Ops! Ocorreu um erro");
                    return CustomResponse();
                }
                sobreViewModel.Id = sobre.Id;

                return CustomResponse(await _sobreService.Atualizar(sobreViewModel));
            }
            catch
            {
                NotificarErro("Ops! Ocorreu um erro");
                return CustomResponse();
            }
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
