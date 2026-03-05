using MediatR;

namespace Cinema.Application.Queries.Sessao
{
    public class GetAllSessoesQuery : IRequest<List<Domain.Entities.Sessao>>
    {
    }
}
