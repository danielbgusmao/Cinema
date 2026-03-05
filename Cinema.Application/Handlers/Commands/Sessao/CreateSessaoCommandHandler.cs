using Cinema.Domain.Interfaces;
using MediatR;

namespace Cinema.Application.Handlers.Commands.Sessao
{
    public class CreateSessaoCommandHandler : IRequestHandler<Cinema.Application.Commands.Sessao.CreateSessaoCommand, bool>
    {
        private readonly ISessaoService _sessaoService;

        public CreateSessaoCommandHandler(ISessaoService sessaoService)
        {
            _sessaoService = sessaoService;
        }

        public Task<bool> Handle(Cinema.Application.Commands.Sessao.CreateSessaoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var sessao = new Domain.Entities.Sessao
                {
                    Id = Guid.NewGuid(),
                    DataInicio = request.DataInicio,
                    DataFim = request.DataFim,
                    ValorIngresso = request.ValorIngresso,
                    TipoAnimacao = request.TipoAnimacao,
                    TipoAudio = request.TipoAudio,
                    FilmeId = request.FilmeId,
                    SalaId = request.SalaId
                };

                _sessaoService.Insert(sessao);

                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao criar sessão", ex);
            }
        }
    }
}
