using MediatR;

namespace Cinema.Application.Commands.Sessao
{
    public class DeleteSessaoCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteSessaoCommand(Guid id)
        {
            Id = id;
        }
    }
}
