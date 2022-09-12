using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain.Entities
{
    public class Filme : BaseEntity
    {
        public Filme()
        {
            Sessoes = new List<Sessao>();
        }
        public string Titulo { get; set; }

        public byte[] Imagem { get; set; }

        public string Descricao { get; set; }

        public string Duracao { get; set; }

        public List<Sessao>? Sessoes { get; set; }

    }
}
