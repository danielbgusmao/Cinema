using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.Domain.Entities;

namespace Cinema.Domain.Interfaces
{
    public interface IFilmeRepository
    {
        void Insert(Filme filme);

        void Update(Filme filme);

        void Delete(Guid id);

        IList<Filme> Select();

        Filme GetById(Guid id);

        Filme TituloEmUso(Filme filme);
    }
}
