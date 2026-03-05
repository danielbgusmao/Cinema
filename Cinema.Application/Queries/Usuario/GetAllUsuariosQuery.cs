using MediatR;

namespace Cinema.Application.Queries.Usuario
{
    public class GetAllUsuariosQuery : IRequest<List<Domain.Entities.Usuario>>
    {
    }
}
