using Cinema.Domain.Entities;
using Cinema.Domain.Interfaces;
using MediatR;

namespace Cinema.Application.Handlers.Commands.Filme
{
    public class UpdateFilmeCommandHandler : IRequestHandler<Cinema.Application.Commands.Filme.UpdateFilmeCommand, bool>
    {
        private readonly IFilmeService _filmeService;

        public UpdateFilmeCommandHandler(IFilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        public Task<bool> Handle(Cinema.Application.Commands.Filme.UpdateFilmeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var filme = new Domain.Entities.Filme
                {
                    Id = request.Id,
                    Titulo = request.Titulo,
                    Imagem = request.Imagem,
                    Descricao = request.Descricao,
                    Duracao = request.Duracao
                };

                _filmeService.Update(filme);

                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao atualizar filme", ex);
            }
        }
    }
}
