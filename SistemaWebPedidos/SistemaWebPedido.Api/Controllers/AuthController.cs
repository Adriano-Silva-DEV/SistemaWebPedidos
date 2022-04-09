using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SistemaWebPedidos.Application.ViewModels.Login;
using System.Threading.Tasks;

namespace SistemaWebPedidos.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost("/nova-conta")]
        public async Task<ActionResult> Registrar(RegistroUsuarioViewModel registroUsuario)
        {
            if (!ModelState.IsValid)
                +return BadRequest(ModelState) ;

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
                return Ok(registroUsuario);
            }
            foreach (var error in result.Errors)
            {
                BadRequest(error);
            }
            return BadRequest(registroUsuario);
        }

        [HttpPost("/entrar")]
        public async Task<IActionResult> Entrar (LoginUsuarioViewModel loginUsuario)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _signInManager.PasswordSignInAsync(loginUsuario.Email, loginUsuario.Password, false, true);

            if (result.Succeeded)
            {
                return Ok(loginUsuario);
            }
            if (result.IsLockedOut)
            {

                return BadRequest("Usuário temporariamente bloqueado por tentatívas inválidas");
            }

            return BadRequest("Usuário ou senha incorretos");
            
        }

    }
}
