using Cinema.Domain.Interfaces;
using MediatR;

namespace Cinema.Application.Handlers.Queries.Filme
{
    public class GetAllFilmesQueryHandler : IRequestHandler<Cinema.Application.Queries.Filme.GetAllFilmesQuery, List<Domain.Entities.Filme>>
    {
        private readonly IFilmeService _filmeService;

        public GetAllFilmesQueryHandler(IFilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        public Task<List<Domain.Entities.Filme>> Handle(Cinema.Application.Queries.Filme.GetAllFilmesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var filmes = _filmeService.Get() as List<Domain.Entities.Filme>;

                return Task.FromResult(filmes ?? new List<Domain.Entities.Filme>());
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao buscar filmes", ex);
            }
        }
    }
}
