using Cinema.Domain.Entities;
using Cinema.Domain.Interfaces;
using Cinema.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Infra.Data.Repository
{
    public class SalaRepository : ISalaRepository
    {
        private readonly Contexto _contexto;

        public SalaRepository(Contexto contexto)
        {
            _contexto = contexto;
        }

        public void Insert(Sala obj)
        {
            _contexto.Sala.Add(obj);
            _contexto.SaveChanges();
        }

        public IList<Sala> Select() =>
            _contexto.Sala.ToList();

        public Sala GetById(Guid id) =>
            _contexto.Sala.Find(id);

    }
}
