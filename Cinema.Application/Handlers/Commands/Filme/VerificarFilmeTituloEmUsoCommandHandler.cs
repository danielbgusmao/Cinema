using Cinema.Domain.Entities;
using Cinema.Domain.Interfaces;
using MediatR;

namespace Cinema.Application.Handlers.Commands.Filme
{
    public class VerificarFilmeTituloEmUsoCommandHandler : IRequestHandler<Cinema.Application.Commands.Filme.VerificarFilmeTituloEmUsoCommand, bool>
    {
        private readonly IFilmeService _filmeService;

        public VerificarFilmeTituloEmUsoCommandHandler(IFilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        public Task<bool> Handle(Cinema.Application.Commands.Filme.VerificarFilmeTituloEmUsoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var filme = new Domain.Entities.Filme
                {
                    Id = request.Id,
                    Titulo = request.Titulo
                };

                var resultado = _filmeService.TituloEmUso(filme);

                return Task.FromResult(resultado != null);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao verificar título em uso", ex);
            }
        }
    }
}
