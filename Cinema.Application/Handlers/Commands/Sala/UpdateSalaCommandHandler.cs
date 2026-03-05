using Cinema.Domain.Interfaces;
using MediatR;

namespace Cinema.Application.Handlers.Commands.Sala
{
    public class UpdateSalaCommandHandler : IRequestHandler<Cinema.Application.Commands.Sala.UpdateSalaCommand, bool>
    {
        private readonly ISalaService _salaService;

        public UpdateSalaCommandHandler(ISalaService salaService)
        {
            _salaService = salaService;
        }

        public Task<bool> Handle(Cinema.Application.Commands.Sala.UpdateSalaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // ISalaService não possui operação de Update, retornando false
                return Task.FromResult(false);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao atualizar sala", ex);
            }
        }
    }
}
