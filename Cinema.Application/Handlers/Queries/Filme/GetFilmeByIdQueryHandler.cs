using Cinema.Domain.Interfaces;
using MediatR;

namespace Cinema.Application.Handlers.Queries.Filme
{
    public class GetFilmeByIdQueryHandler : IRequestHandler<Cinema.Application.Queries.Filme.GetFilmeByIdQuery, Domain.Entities.Filme>
    {
        private readonly IFilmeService _filmeService;

        public GetFilmeByIdQueryHandler(IFilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        public Task<Domain.Entities.Filme> Handle(Cinema.Application.Queries.Filme.GetFilmeByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var filme = _filmeService.GetById(request.Id) as Domain.Entities.Filme;

                if (filme == null)
                    throw new KeyNotFoundException("Filme não encontrado");

                return Task.FromResult(filme);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao buscar filme", ex);
            }
        }
    }
}
