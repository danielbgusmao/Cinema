using MediatR;

namespace Cinema.Application.Queries.Sessao
{
    public class GetSessaoByIdQuery : IRequest<Domain.Entities.Sessao>
    {
        public Guid Id { get; set; }

        public GetSessaoByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
