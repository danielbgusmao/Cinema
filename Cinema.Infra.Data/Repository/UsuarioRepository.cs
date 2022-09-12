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
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Contexto _contexto;

        public UsuarioRepository(Contexto contexto)
        {
            _contexto = contexto;
        }
        public Usuario GetByEmailSenha(string email, string senha) =>
            _contexto.Usuario.Where(x => x.Email == email && x.Senha == senha).FirstOrDefault();

        public void Insert(Usuario usuario)
        {
            _contexto.Usuario.Add(usuario);
            _contexto.SaveChanges();
        }

        public void Update(Usuario usuario)
        {
            _contexto.Usuario.Update(usuario);
            _contexto.SaveChanges();
        }

        public void Delete(Guid id)
        {
            _contexto.Usuario.Remove(GetById(id));
            _contexto.SaveChanges();
        }

        public IList<Usuario> Select() =>
            _contexto.Usuario.ToList();

        public Usuario GetById(Guid id) =>
            _contexto.Usuario.Find(id);

    }
}
