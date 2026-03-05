using Cinema.Domain.Interfaces;
using MediatR;

namespace Cinema.Application.Handlers.Commands.Sala
{
    public class CreateSalaCommandHandler : IRequestHandler<Cinema.Application.Commands.Sala.CreateSalaCommand, bool>
    {
        private readonly ISalaService _salaService;

        public CreateSalaCommandHandler(ISalaService salaService)
        {
            _salaService = salaService;
        }

        public Task<bool> Handle(Cinema.Application.Commands.Sala.CreateSalaCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var sala = new Domain.Entities.Sala
                {
                    Id = Guid.NewGuid(),
                    Nome = request.Nome,
                    QuantidadeAssentos = request.QuantidadeAssentos
                };

                _salaService.Insert(sala);

                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao criar sala", ex);
            }
        }
    }
}
