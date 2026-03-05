using Cinema.Domain.Interfaces;
using MediatR;

namespace Cinema.Application.Handlers.Commands.Usuario
{
    public class UpdateUsuarioCommandHandler : IRequestHandler<Cinema.Application.Commands.Usuario.UpdateUsuarioCommand, bool>
    {
        private readonly IUsuarioService _usuarioService;

        public UpdateUsuarioCommandHandler(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public Task<bool> Handle(Cinema.Application.Commands.Usuario.UpdateUsuarioCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var usuario = new Domain.Entities.Usuario
                {
                    Id = request.Id,
                    Nome = request.Nome,
                    Email = request.Email,
                    Senha = request.Senha
                };

                _usuarioService.Update(usuario);

                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao atualizar usuário", ex);
            }
        }
    }
}
