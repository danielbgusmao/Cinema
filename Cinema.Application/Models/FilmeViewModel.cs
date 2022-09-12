using Cinema.Domain.Entities;

namespace Cinema.Application.Models
{
    public class FilmeViewModel : EntityViewModel
    {
        public string Titulo { get; set; }

        public byte[] Imagem { get; set; }

        public string Descricao { get; set; }

        public string Duracao { get; set; }

        public List<Sessao>? Sessoes { get; set; }
    }
}
