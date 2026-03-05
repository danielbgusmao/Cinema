using Cinema.Domain.Interfaces;
using MediatR;

namespace Cinema.Application.Handlers.Queries.Sessao
{
    public class GetSessaoByIdQueryHandler : IRequestHandler<Cinema.Application.Queries.Sessao.GetSessaoByIdQuery, Domain.Entities.Sessao>
    {
        private readonly ISessaoService _sessaoService;

        public GetSessaoByIdQueryHandler(ISessaoService sessaoService)
        {
            _sessaoService = sessaoService;
        }

        public Task<Domain.Entities.Sessao> Handle(Cinema.Application.Queries.Sessao.GetSessaoByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var sessao = _sessaoService.GetById(request.Id) as Domain.Entities.Sessao;

                if (sessao == null)
                    throw new KeyNotFoundException("Sessão não encontrada");

                return Task.FromResult(sessao);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao buscar sessão", ex);
            }
        }
    }
}
