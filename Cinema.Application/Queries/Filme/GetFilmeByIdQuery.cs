using Cinema.Domain.Entities;
using MediatR;

namespace Cinema.Application.Queries.Filme
{
    public class GetFilmeByIdQuery : IRequest<Domain.Entities.Filme>
    {
        public Guid Id { get; set; }

        public GetFilmeByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
