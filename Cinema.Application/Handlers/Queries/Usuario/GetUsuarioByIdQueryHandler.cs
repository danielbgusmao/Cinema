using Cinema.Domain.Interfaces;
using MediatR;

namespace Cinema.Application.Handlers.Queries.Usuario
{
    public class GetUsuarioByIdQueryHandler : IRequestHandler<Cinema.Application.Queries.Usuario.GetUsuarioByIdQuery, Domain.Entities.Usuario>
    {
        private readonly IUsuarioService _usuarioService;

        public GetUsuarioByIdQueryHandler(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public Task<Domain.Entities.Usuario> Handle(Cinema.Application.Queries.Usuario.GetUsuarioByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var usuario = _usuarioService.GetById(request.Id) as Domain.Entities.Usuario;

                if (usuario == null)
                    throw new KeyNotFoundException("Usuário não encontrado");

                return Task.FromResult(usuario);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao buscar usuário", ex);
            }
        }
    }
}
