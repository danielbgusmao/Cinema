using Cinema.Application.Models;
using Cinema.Domain.Entities;
using Cinema.Domain.Interfaces;
using Cinema.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private IUsuarioService _usuarioService;
        private ITokenService _tokenService;
        
        public LoginController(IUsuarioService usuarioService, ITokenService tokenService)
        {
            _usuarioService = usuarioService;
            _tokenService = tokenService;
        }

        [HttpPost]
        public async Task<TokenResponse> AuthenticateAsync([FromBody] LoginModel usuario)
        {
            Usuario usuarioDB = _usuarioService.GetByEmailSenha(usuario.Email, usuario.Senha);

            if (usuarioDB == null)
                return new TokenResponse();

            var token = await _tokenService.GenerateToken(usuarioDB);
            return token;
        }
    }
}
