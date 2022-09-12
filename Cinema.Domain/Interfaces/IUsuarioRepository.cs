using Cinema.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        public Usuario GetByEmailSenha(string email, string senha);

        void Insert(Usuario usuario);

        void Update(Usuario usuario);

        void Delete(Guid id);

        IList<Usuario> Select();

        Usuario GetById(Guid id);

    }
}
