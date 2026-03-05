using MediatR;

namespace Cinema.Application.Commands.Usuario
{
    public class DeleteUsuarioCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public DeleteUsuarioCommand(Guid id)
        {
            Id = id;
        }
    }
}
