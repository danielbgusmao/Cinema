using MediatR;

namespace Cinema.Application.Commands.Filme
{
    public class VerificarFilmeTituloEmUsoCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }

        public VerificarFilmeTituloEmUsoCommand(Guid id, string titulo)
        {
            Id = id;
            Titulo = titulo;
        }
    }
}
