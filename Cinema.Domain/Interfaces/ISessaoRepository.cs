using Cinema.Domain.Entities;
using Cinema.Domain.Models;

namespace Cinema.Domain.Interfaces
{
    public interface ISessaoRepository
    {
        void Insert(Sessao sessao);

        void Update(Sessao sessao);

        void Delete(Guid id);

        IList<Sessao> Select();

        Sessao GetById(Guid id);

        Sessao CalculaDataFim(Sessao sessao);

        Task<List<SessaoSugestaoDataInicioViewModel>> SugestaoDataInicio(Sessao sessao, string connection);

        bool VerificarSalaOcupada(Sessao sessao);

    }
}
