using MediatR;

namespace Cinema.Application.Commands.Filme
{
    public class DeleteFilmeCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteFilmeCommand(Guid id)
        {
            Id = id;
        }
    }
}
