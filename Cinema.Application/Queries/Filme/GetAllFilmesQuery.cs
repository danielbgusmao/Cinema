using Cinema.Domain.Entities;
using MediatR;

namespace Cinema.Application.Queries.Filme
{
    public class GetAllFilmesQuery : IRequest<List<Domain.Entities.Filme>>
    {
    }
}
