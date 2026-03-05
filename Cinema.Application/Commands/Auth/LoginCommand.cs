using Cinema.Application.Models;
using Cinema.Domain.Models;
using MediatR;

namespace Cinema.Application.Commands.Auth
{
    public class LoginCommand : IRequest<TokenResponse>
    {
        public string Email { get; set; }
        public string Senha { get; set; }

        public LoginCommand(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }
    }
}
