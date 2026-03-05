using Cinema.Domain.Interfaces;
using MediatR;

namespace Cinema.Application.Handlers.Queries.Sala
{
    public class GetAllSalasQueryHandler : IRequestHandler<Cinema.Application.Queries.Sala.GetAllSalasQuery, List<Domain.Entities.Sala>>
    {
        private readonly ISalaService _salaService;

        public GetAllSalasQueryHandler(ISalaService salaService)
        {
            _salaService = salaService;
        }

        public Task<List<Domain.Entities.Sala>> Handle(Cinema.Application.Queries.Sala.GetAllSalasQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var salas = _salaService.Get() as List<Domain.Entities.Sala>;

                return Task.FromResult(salas ?? new List<Domain.Entities.Sala>());
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao buscar salas", ex);
            }
        }
    }
}
