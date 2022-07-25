using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SistemaWebPedidos.Application.Extensions;
using SistemaWebPedidos.Application.Interfaces;
using SistemaWebPedidos.Application.ViewModels.Login;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SistemaWebPedidos.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : MainController
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IUsuarioService _usuarioService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppSettings _appSettings;
        
    

        public AuthController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager,
            INotificador notificador, IOptions<AppSettings> appSettings, IUser appUser, IUsuarioService usuarioService) : base(notificador,appUser)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _appSettings = appSettings.Value;
            _usuarioService = usuarioService;
        }

        [HttpPost("nova-conta")]
        public async Task<ActionResult> Registrar(RegistroUsuarioViewModel registroUsuario)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);
         
            var user = new IdentityUser
            {
                UserName = registroUsuario.Email,
                Email = registroUsuario.Email,
                EmailConfirmed = true,
            };
           
            var result = await _userManager.CreateAsync(user, registroUsuario.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);

               var usuarioRegistro = await _userManager.FindByEmailAsync(registroUsuario.Email);
                
                registroUsuario.Usuario.IdIdentity = new Guid (usuarioRegistro.Id);
                registroUsuario.Usuario.endereco.Id = new Guid(usuarioRegistro.Id);

                await _usuarioService.Salvar(registroUsuario.Usuario);

                return CustomResponse( await GerarJsonTokenAsync(user.Email));
            }
            foreach (var error in result.Errors)
            {
                NotificarErro(error.Description);
            }
            return CustomResponse(registroUsuario);
        }

        [HttpPut("alterar-dados-usuario")]
        public async Task<ActionResult> AlterarUsuario(RegistroUsuarioViewModel registroUsuario)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);
            try
            {

                var user = await _userManager.FindByIdAsync(_appUser.GetUserId().ToString());

 
                var result = await _userManager.ChangePasswordAsync(user, registroUsuario.PasswordOld, registroUsuario.Password) ;

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        NotificarErro(error.Description);
                    }
                    return CustomResponse();
                }

                user.Email = registroUsuario.Email;
                user.UserName = registroUsuario.Email;
                await _userManager.UpdateAsync(user); ;


                var dadosUsuario = await _usuarioService.ObterPorIdIdentity(_appUser.GetUserId());
                dadosUsuario.Telefone = registroUsuario.Usuario.Telefone;
                dadosUsuario.Nome = registroUsuario.Usuario.Nome;
                dadosUsuario.Sobrenome = registroUsuario.Usuario.Sobrenome;

                await _usuarioService.Atualizar(dadosUsuario);
                return CustomResponse(await GerarJsonTokenAsync(user.Email));
            } catch (Exception ex)
            {
                NotificarErro(ex.Message);
                return CustomResponse();
            }
         
        }

        [HttpPost("entrar")]
        public async Task<IActionResult> Entrar(LoginUsuarioViewModel loginUsuario)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            var result = await _signInManager.PasswordSignInAsync(loginUsuario.Email, loginUsuario.Password, false, true);

            if (result.Succeeded)
            {
                return CustomResponse(await GerarJsonTokenAsync(loginUsuario.Email));
            }
            if (result.IsLockedOut)
            {
                NotificarErro("Este Usuário foi temporariamente bloqueado por tentatívas inválidas");
                return CustomResponse(loginUsuario);
            }

            NotificarErro("Usuário ou senha incorretos, tente novamente");
            return CustomResponse(loginUsuario);

        }

        [Authorize]
        [HttpGet("dados-usuario")]
        public async Task<IActionResult> GetDadosUsuario()
        {

            try
            {
                var usuarioViewModel = new RegistroUsuarioViewModel
                {
                    Email = _appUser.GetUserEmail(),
                    Usuario = await _usuarioService.ObterPorIdIdentity(_appUser.GetUserId())
                };

                return CustomResponse(usuarioViewModel);
            }
            catch (Exception ex)
            {
                NotificarErro("Ops! Ocorreu um erro");
                NotificarErro(ex.Message);
                return CustomResponse();
            }
       
        }

        private async Task<LoginResponseViewModel> GerarJsonTokenAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var usuarioInfo =  await _usuarioService.ObterPorIdIdentity(new Guid(user.Id));
            var claims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);

            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));
            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim("role", userRole));
            }

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
                Subject = identityClaims,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });
            var encodedToken = tokenHandler.WriteToken(token);


            var response = new LoginResponseViewModel
            {
                AccessToken = encodedToken,
                ExpiresIn = TimeSpan.FromHours(_appSettings.ExpiracaoHoras).TotalSeconds,
                UserToken = new UsuarioTokenViewModel
                {
                    Id = user.Id,
                    Nome = usuarioInfo.Nome,
                    Email = user.Email,
                    Claims = claims.Select(c => new ClaimViewModel { Type = c.Type, Value = c.Value })
                }
            };

            return response;
        }

        private static long ToUnixEpochDate(DateTime date)
           => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
    
}
}