using MediatR;

namespace Cinema.Application.Commands.Sala
{
    public class CreateSalaCommand : IRequest<bool>
    {
        public string Nome { get; set; }
        public int QuantidadeAssentos { get; set; }

        public CreateSalaCommand(string nome, int quantidadeAssentos)
        {
            Nome = nome;
            QuantidadeAssentos = quantidadeAssentos;
        }
    }
}
