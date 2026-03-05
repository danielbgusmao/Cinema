using Cinema.Domain.Interfaces;
using Cinema.Domain.Models;
using MediatR;

namespace Cinema.Application.Handlers.Commands.Auth
{
    public class LoginCommandHandler : IRequestHandler<Cinema.Application.Commands.Auth.LoginCommand, TokenResponse>
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ITokenService _tokenService;

        public LoginCommandHandler(IUsuarioService usuarioService, ITokenService tokenService)
        {
            _usuarioService = usuarioService;
            _tokenService = tokenService;
        }

        public async Task<TokenResponse> Handle(Cinema.Application.Commands.Auth.LoginCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var usuarioDB = _usuarioService.GetByEmailSenha(request.Email, request.Senha);

                if (usuarioDB == null)
                    return new TokenResponse();

                var token = await _tokenService.GenerateToken(usuarioDB);
                return token;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao fazer login", ex);
            }
        }
    }
}
