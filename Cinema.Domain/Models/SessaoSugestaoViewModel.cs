

namespace Cinema.Domain.Models
{
    public class SessaoSugestaoViewModel
    {
        public DateTime DataInicio { get; set; }

        public Guid FilmeId { get; set; }

        public Guid SalaId { get; set; }

    }
}
