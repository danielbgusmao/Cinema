using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinema.Domain.Entities;
using System.Data.SqlClient;
using Cinema.Domain.Models;

namespace Cinema.Domain.Interfaces
{
    public interface ISessaoService
    {
        Sessao Insert(Sessao sessao);

        void Delete(Guid id);

        IEnumerable<Sessao> Get();

        Sessao GetById(Guid id);

        Sessao Update(Sessao sessao);

        Sessao CalculaDataFim(Sessao sessao);

        List<SessaoSugestaoDataInicioViewModel> SugestaoDataInicio(Sessao sessao);

        bool VerificarSalaOcupada(Sessao sessao);

        bool ValidaDeleteSessao(Sessao sessao);
    }
}
