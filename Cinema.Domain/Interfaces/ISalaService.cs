using Cinema.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain.Interfaces
{
    public interface ISalaService
    {
        IEnumerable<Sala> Get();

        Sala Insert(Sala sala);

        Sala GetById(Guid id);

        void VerificarEPopularTabela();
    }
}
