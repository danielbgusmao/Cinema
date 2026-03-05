using Cinema.Domain.Interfaces;
using MediatR;

namespace Cinema.Application.Handlers.Queries.Sala
{
    public class GetSalaByIdQueryHandler : IRequestHandler<Cinema.Application.Queries.Sala.GetSalaByIdQuery, Domain.Entities.Sala>
    {
        private readonly ISalaService _salaService;

        public GetSalaByIdQueryHandler(ISalaService salaService)
        {
            _salaService = salaService;
        }

        public Task<Domain.Entities.Sala> Handle(Cinema.Application.Queries.Sala.GetSalaByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var sala = _salaService.GetById(request.Id) as Domain.Entities.Sala;

                if (sala == null)
                    throw new KeyNotFoundException("Sala não encontrada");

                return Task.FromResult(sala);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao buscar sala", ex);
            }
        }
    }
}
