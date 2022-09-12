using Cinema.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain.Interfaces
{
    public interface IUsuarioService
    {
        Usuario GetByEmailSenha(string email, string senha);

        Usuario Insert(Usuario usuario);

        void Delete(Guid id);

        IEnumerable<Usuario> Get();

        Usuario GetById(Guid id);

        Usuario Update(Usuario usuario);

    }
}
