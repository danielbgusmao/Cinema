using Cinema.Domain.Interfaces;
using MediatR;

namespace Cinema.Application.Handlers.Commands.Sessao
{
    public class DeleteSessaoCommandHandler : IRequestHandler<Cinema.Application.Commands.Sessao.DeleteSessaoCommand, bool>
    {
        private readonly ISessaoService _sessaoService;

        public DeleteSessaoCommandHandler(ISessaoService sessaoService)
        {
            _sessaoService = sessaoService;
        }

        public Task<bool> Handle(Cinema.Application.Commands.Sessao.DeleteSessaoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _sessaoService.Delete(request.Id);

                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao deletar sessão", ex);
            }
        }
    }
}
