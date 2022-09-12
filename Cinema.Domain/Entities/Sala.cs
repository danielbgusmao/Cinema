using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain.Entities
{
    public class Sala : BaseEntity
    {
        public Sala()
        {
            Sessoes = new List<Sessao>();
        }

        public string Nome { get; set; }

        public int QuantidadeAssentos { get; set; }

        public List<Sessao> Sessoes { get; set; }

    }
}
