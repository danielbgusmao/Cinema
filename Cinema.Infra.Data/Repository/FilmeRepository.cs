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
    public class FilmeRepository : IFilmeRepository
    {
        private readonly Contexto _contexto;

        public FilmeRepository(Contexto contexto)
        {
            _contexto = contexto;
        }

        public void Insert(Filme filme)
        {
            _contexto.Filme.Add(filme);
            _contexto.SaveChanges();
        }

        public void Update(Filme filme)
        {
            _contexto.Filme.Update(filme);
            _contexto.SaveChanges();
        }

        public void Delete(Guid id)
        {
            _contexto.Filme.Remove(GetById(id));
            _contexto.SaveChanges();
        }

        public IList<Filme> Select() =>
            _contexto.Filme.ToList();

        public Filme GetById(Guid id) =>
            _contexto.Filme.Find(id);


        public Filme TituloEmUso(Filme filme)
        {
            Filme entity = new();

            entity = _contexto.Filme.Where(x => x.Titulo == filme.Titulo).FirstOrDefault();

            return entity;
        }
    }
}
