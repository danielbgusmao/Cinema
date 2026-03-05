using MediatR;

namespace Cinema.Application.Commands.Sala
{
    public class UpdateSalaCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int QuantidadeAssentos { get; set; }

        public UpdateSalaCommand(Guid id, string nome, int quantidadeAssentos)
        {
            Id = id;
            Nome = nome;
            QuantidadeAssentos = quantidadeAssentos;
        }
    }
}
