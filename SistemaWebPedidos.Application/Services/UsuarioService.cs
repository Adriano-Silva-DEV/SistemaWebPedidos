using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaWebPedidos.Application.Interfaces;
using SistemaWebPedidos.Application.ViewModels;
using SistemaWebPedidos.Core.Entities;
using SistemaWebPedidos.Core.Interfaces.Repositories;
using SistemaWebPedidos.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebPedidos.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository  _usuarioRepository;

        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            this._usuarioRepository = usuarioRepository;
            this._mapper = mapper;
        }


        public async Task<List<UsuarioViewModel>> Listar()
        {
            return _mapper.Map<List<UsuarioViewModel>>( await _usuarioRepository.ObterTodos());
        }

        public async Task<UsuarioViewModel> Salvar(UsuarioViewModel usuarioViewModel)
        {
            var usuario = _mapper.Map<Usuario>(usuarioViewModel);
            return _mapper.Map<UsuarioViewModel>( await _usuarioRepository.Adcionar(usuario));
           
        }

        public async Task<UsuarioViewModel> Atualizar(UsuarioViewModel usuarioViewModel)
        {

           var user = await _usuarioRepository.ObterPorId(usuarioViewModel.Id);

            if (user is null) new Exception();

            var sobre = _mapper.Map<Usuario>(usuarioViewModel);
            await _usuarioRepository.Atualizar(sobre);
            return usuarioViewModel;
        }

        public async Task<UsuarioViewModel> ObterPorIdIdentity(Guid id)
        {
            return _mapper.Map<UsuarioViewModel>(await _usuarioRepository.ObterPorIdIdentity(id));
        }

        public async Task<UsuarioViewModel> ObterPorId(Guid id)
        {
            return _mapper.Map<UsuarioViewModel>(await _usuarioRepository.ObterPorId(id));
        }

    }
}
