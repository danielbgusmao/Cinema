using Cinema.Domain.Interfaces;
using MediatR;

namespace Cinema.Application.Handlers.Queries.Usuario
{
    public class GetAllUsuariosQueryHandler : IRequestHandler<Cinema.Application.Queries.Usuario.GetAllUsuariosQuery, List<Domain.Entities.Usuario>>
    {
        private readonly IUsuarioService _usuarioService;

        public GetAllUsuariosQueryHandler(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public Task<List<Domain.Entities.Usuario>> Handle(Cinema.Application.Queries.Usuario.GetAllUsuariosQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var usuarios = _usuarioService.Get() as List<Domain.Entities.Usuario>;

                return Task.FromResult(usuarios ?? new List<Domain.Entities.Usuario>());
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao buscar usuários", ex);
            }
        }
    }
}
