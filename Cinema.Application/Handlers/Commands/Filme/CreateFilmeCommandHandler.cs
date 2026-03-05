using Cinema.Domain.Entities;
using Cinema.Domain.Interfaces;
using Cinema.Service.Validators;
using FluentValidation;
using MediatR;

namespace Cinema.Application.Handlers.Commands.Filme
{
    public class CreateFilmeCommandHandler : IRequestHandler<Cinema.Application.Commands.Filme.CreateFilmeCommand, bool>
    {
        private readonly IFilmeService _filmeService;

        public CreateFilmeCommandHandler(IFilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        public Task<bool> Handle(Cinema.Application.Commands.Filme.CreateFilmeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var filme = new Domain.Entities.Filme
                {
                    Id = Guid.NewGuid(),
                    Titulo = request.Titulo,
                    Imagem = request.Imagem,
                    Descricao = request.Descricao,
                    Duracao = request.Duracao
                };

                _filmeService.Insert(filme);

                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Erro ao criar filme", ex);
            }
        }
    }
}
