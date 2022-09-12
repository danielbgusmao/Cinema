using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.Domain.Entities;

namespace Cinema.Domain.Interfaces
{
    public interface IFilmeService
    {
        bool Insert(Filme filme);

        bool Delete(Guid id);

        IEnumerable<Filme> Get();

        Filme GetById(Guid id);

        bool Update(Filme filme);

        Filme TituloEmUso(Filme filme);
    }
}
