using Cinema.Domain.Interfaces;
using MediatR;

namespace Cinema.Application.Handlers.Commands.Sala
{
    public class DeleteSalaCommandHandler : IRequestHandler<Cinema.Application.Commands.Sala.DeleteSalaCommand, bool>
    {
        private readonly ISalaService _salaService;

        public DeleteSalaCommandHandler(ISalaService salaService)
        {
            _salaService = salaService;
        }

        public Task<bool> Handle(Cinema.Application.Commands.Sala.DeleteSalaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // ISalaService não possui operação de Delete, retornando false
                return Task.FromResult(false);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao deletar sala", ex);
            }
        }
    }
}
