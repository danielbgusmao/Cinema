using Cinema.Domain.Entities;
using MediatR;

namespace Cinema.Application.Commands.Filme
{
    public class UpdateFilmeCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public byte[] Imagem { get; set; }
        public string Descricao { get; set; }
        public string Duracao { get; set; }

        public UpdateFilmeCommand(Guid id, string titulo, byte[] imagem, string descricao, string duracao)
        {
            Id = id;
            Titulo = titulo;
            Imagem = imagem;
            Descricao = descricao;
            Duracao = duracao;
        }
    }
}
