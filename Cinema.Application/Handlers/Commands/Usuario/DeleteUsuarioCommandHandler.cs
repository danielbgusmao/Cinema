using Cinema.Domain.Interfaces;
using MediatR;

namespace Cinema.Application.Handlers.Commands.Usuario
{
    public class DeleteUsuarioCommandHandler : IRequestHandler<Cinema.Application.Commands.Usuario.DeleteUsuarioCommand, bool>
    {
        private readonly IUsuarioService _usuarioService;

        public DeleteUsuarioCommandHandler(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public Task<bool> Handle(Cinema.Application.Commands.Usuario.DeleteUsuarioCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _usuarioService.Delete(request.Id);

                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao deletar usuário", ex);
            }
        }
    }
}
