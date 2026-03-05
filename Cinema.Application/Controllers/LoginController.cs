using Cinema.Application.Commands.Auth;
using Cinema.Application.Models;
using Cinema.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private readonly IMediator _mediator;
        
        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<TokenResponse> AuthenticateAsync([FromBody] LoginModel usuario)
        {
            var command = new LoginCommand(usuario.Email, usuario.Senha);
            var token = await _mediator.Send(command);
            return token;
        }
    }
}
