using Cinema.Domain.Interfaces;
using MediatR;

namespace Cinema.Application.Handlers.Commands.Sessao
{
    public class UpdateSessaoCommandHandler : IRequestHandler<Cinema.Application.Commands.Sessao.UpdateSessaoCommand, bool>
    {
        private readonly ISessaoService _sessaoService;

        public UpdateSessaoCommandHandler(ISessaoService sessaoService)
        {
            _sessaoService = sessaoService;
        }

        public Task<bool> Handle(Cinema.Application.Commands.Sessao.UpdateSessaoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var sessao = new Domain.Entities.Sessao
                {
                    Id = request.Id,
                    DataInicio = request.DataInicio,
                    DataFim = request.DataFim,
                    ValorIngresso = request.ValorIngresso,
                    TipoAnimacao = request.TipoAnimacao,
                    TipoAudio = request.TipoAudio,
                    FilmeId = request.FilmeId,
                    SalaId = request.SalaId
                };

                _sessaoService.Update(sessao);

                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao atualizar sessão", ex);
            }
        }
    }
}
