using MediatR;

namespace Cinema.Application.Queries.Sala
{
    public class GetAllSalasQuery : IRequest<List<Domain.Entities.Sala>>
    {
    }
}
