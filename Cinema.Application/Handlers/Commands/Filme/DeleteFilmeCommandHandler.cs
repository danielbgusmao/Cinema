using Cinema.Domain.Interfaces;
using MediatR;

namespace Cinema.Application.Handlers.Commands.Filme
{
    public class DeleteFilmeCommandHandler : IRequestHandler<Cinema.Application.Commands.Filme.DeleteFilmeCommand, bool>
    {
        private readonly IFilmeService _filmeService;

        public DeleteFilmeCommandHandler(IFilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        public Task<bool> Handle(Cinema.Application.Commands.Filme.DeleteFilmeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _filmeService.Delete(request.Id);

                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao deletar filme", ex);
            }
        }
    }
}
