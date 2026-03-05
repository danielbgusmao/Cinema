using MediatR;

namespace Cinema.Application.Queries.Sala
{
    public class GetSalaByIdQuery : IRequest<Domain.Entities.Sala>
    {
        public Guid Id { get; set; }

        public GetSalaByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
