using MediatR;

namespace Cinema.Application.Commands.Sala
{
    public class DeleteSalaCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteSalaCommand(Guid id)
        {
            Id = id;
        }
    }
}
