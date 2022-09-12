using Cinema.Domain.Entities;

namespace Cinema.Application.Models
{
    public class SalaModel
    {
        public string Nome { get; set; }

        public int QuantidadeAssentos { get; set; }

        public List<Sessao> Sessoes { get; set; }
    }
}
