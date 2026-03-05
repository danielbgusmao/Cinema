using Cinema.Domain.Interfaces;
using MediatR;

namespace Cinema.Application.Handlers.Commands.Usuario
{
    public class CreateUsuarioCommandHandler : IRequestHandler<Cinema.Application.Commands.Usuario.CreateUsuarioCommand, bool>
    {
        private readonly IUsuarioService _usuarioService;

        public CreateUsuarioCommandHandler(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public Task<bool> Handle(Cinema.Application.Commands.Usuario.CreateUsuarioCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var usuario = new Domain.Entities.Usuario
                {
                    Id = Guid.NewGuid(),
                    Nome = request.Nome,
                    Email = request.Email,
                    Senha = request.Senha
                };

                _usuarioService.Insert(usuario);

                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao criar usuário", ex);
            }
        }
    }
}
