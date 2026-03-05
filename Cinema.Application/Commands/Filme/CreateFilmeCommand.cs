using Cinema.Domain.Entities;
using MediatR;

namespace Cinema.Application.Commands.Filme
{
    public class CreateFilmeCommand : IRequest<bool>
    {
        public string Titulo { get; set; }
        public byte[] Imagem { get; set; }
        public string Descricao { get; set; }
        public string Duracao { get; set; }

        public CreateFilmeCommand(string titulo, byte[] imagem, string descricao, string duracao)
        {
            Titulo = titulo;
            Imagem = imagem;
            Descricao = descricao;
            Duracao = duracao;
        }
    }
}
