using Cinema.Domain.Interfaces;
using MediatR;

namespace Cinema.Application.Handlers.Queries.Sessao
{
    public class GetAllSessoesQueryHandler : IRequestHandler<Cinema.Application.Queries.Sessao.GetAllSessoesQuery, List<Domain.Entities.Sessao>>
    {
        private readonly ISessaoService _sessaoService;

        public GetAllSessoesQueryHandler(ISessaoService sessaoService)
        {
            _sessaoService = sessaoService;
        }

        public Task<List<Domain.Entities.Sessao>> Handle(Cinema.Application.Queries.Sessao.GetAllSessoesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var sessoes = _sessaoService.Get() as List<Domain.Entities.Sessao>;

                return Task.FromResult(sessoes ?? new List<Domain.Entities.Sessao>());
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao buscar sessões", ex);
            }
        }
    }
}
