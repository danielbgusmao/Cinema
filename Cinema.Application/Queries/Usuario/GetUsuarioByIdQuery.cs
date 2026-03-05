using MediatR;

namespace Cinema.Application.Queries.Usuario
{
    public class GetUsuarioByIdQuery : IRequest<Domain.Entities.Usuario>
    {
        public Guid Id { get; set; }

        public GetUsuarioByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
