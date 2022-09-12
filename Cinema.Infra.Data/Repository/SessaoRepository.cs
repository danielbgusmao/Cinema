using Cinema.Domain.Entities;
using Cinema.Domain.Interfaces;
using Cinema.Domain.Models;
using Cinema.Infra.Data.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace Cinema.Infra.Data.Repository
{
    public class SessaoRepository : ISessaoRepository
    {
        private readonly Contexto _contexto;

        public SessaoRepository(Contexto contexto)
        {
            _contexto = contexto;
        }

        public void Insert(Sessao sesao)
        {
            _contexto.Sessao.Add(sesao);
            _contexto.SaveChanges();
        }

        public void Update(Sessao sesao)
        {
            _contexto.Sessao.Update(sesao);
            _contexto.SaveChanges();
        }

        public void Delete(Guid id)
        {
            _contexto.Sessao.Remove(GetById(id));
            _contexto.SaveChanges();
        }

        public IList<Sessao> Select()
        {
            var query = from se in _contexto.Sessao
                        join sa in _contexto.Sala
                        on se.Sala.Id equals sa.Id
                        join fi in _contexto.Filme
                        on se.Filme.Id equals fi.Id
                        select new Sessao
                        {
                            Id = se.Id,
                            DataInicio = se.DataInicio,
                            DataFim = se.DataFim,
                            ValorIngresso = se.ValorIngresso,
                            TipoAnimacao = se.TipoAnimacao,
                            TipoAudio = se.TipoAudio,
                            FilmeId = se.FilmeId,
                            SalaId = se.SalaId,
                            Sala = sa,
                            Filme = fi
                        };

            return query.ToList();
        }

        public Sessao GetById(Guid id) =>
            _contexto.Sessao.Find(id);

        public Sessao CalculaDataFim(Sessao sessao)
        {
            Filme filme = _contexto.Filme.Find(sessao.FilmeId);

            Sessao entity = sessao;

            entity.DataFim = sessao.DataInicio + TimeSpan.Parse(filme.Duracao);

            return entity;
        }


        public async Task<List<SessaoSugestaoDataInicioViewModel>> SugestaoDataInicio(Sessao sessao,  string conn)
        {
            try
            {
                List<SessaoSugestaoDataInicioViewModel> registros = new List<SessaoSugestaoDataInicioViewModel>();

                SqlConnection connection = new SqlConnection(conn);

                String query = " DECLARE @diaSelecionado DATETIME2 = '" + sessao.DataInicio.Date + "';" +
                " DECLARE @filmeId UNIQUEIDENTIFIER= '" + sessao.FilmeId + "';" +
                " DECLARE @salaId UNIQUEIDENTIFIER= '" + sessao.SalaId + "';";
                query +=
                " DECLARE @diaSeguinte DATETIME2 = DATEADD(DAY, 1, @diaSelecionado); " +
                " DECLARE @duracao varchar(5); " +
                " DECLARE @duracaoHora varchar(2); " +
                " DECLARE @duracaoMinuto varchar(2); " +
                " DECLARE @disponivel smallint; " +
                " set @duracao = dbo.fn_DuracaoFilme(@filmeId); " +
                " set @duracaoHora = SUBSTRING(@duracao, 1, 2); " +
                " set @duracaoMinuto = SUBSTRING(@duracao, 4, 2); " +
                " DECLARE @paramDataInicio DATETIME2 = @diaSelecionado; " +
                " DECLARE @paramDataFim DATETIME2 = @diaSelecionado; " +
                " DECLARE @t TABLE(DataInicio DATETIME2, DataFim DATETIME2, Disponivel smallint, FilmeId UNIQUEIDENTIFIER, SalaId UNIQUEIDENTIFIER); " +
                " DECLARE @cont INT; " +
                " set @cont = 1; " +
                " SET @paramDataInicio = @diaSelecionado; " +
                " SET @paramDataFim = @diaSelecionado; ";

                query += " while (@paramDataInicio < @diaSeguinte)  " +
                "    BEGIN " +
                "        set @paramDataFim = DATEADD(HOUR, CAST(@duracaoHora AS INT), @paramDataInicio); " +
                " set @paramDataFim = DATEADD(MINUTE, CAST(@duracaoMinuto AS INT), @paramDataFim); " +
                " set @disponivel = (SELECT CASE  " +
                " WHEN(select count(*) from fn_SugestaoDeSessoes(@paramDataInicio, @paramDataFim, @filmeId, @salaId)) = 0" +
                " THEN 1 ELSE 0 END); ";

                query += " INSERT INTO @t(dataInicio, dataFim, disponivel, filmeId, salaId) values(@paramDataInicio, @paramDataFim, @disponivel, @filmeId, @salaId); " +
                " set @paramDataInicio = DATEADD(HOUR, CAST(@duracaoHora AS INT) + 1, @paramDataInicio); " +
                " END ";
                query += " SELECT * FROM @t order by DataInicio;";


                await connection.OpenAsync();

                SqlCommand command = new SqlCommand(query, connection);

                int result = await command.ExecuteNonQueryAsync();

                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    
                    while (reader.Read())
                    {
                        SessaoSugestaoDataInicioViewModel sessaoSugestao = new SessaoSugestaoDataInicioViewModel()
                        {
                            DataInicio = (DateTime)reader["DataInicio"],
                            DataFim = (DateTime)reader["DataFim"],
                            Disponivel = Int16.Parse(reader["Disponivel"].ToString()),
                            FilmeId = Guid.Parse(reader["FilmeId"].ToString()),
                            SalaId = Guid.Parse(reader["SalaId"].ToString())
                        };

                        registros.Add(sessaoSugestao);
                    }
                    
                }

                connection.Close();


                return registros;
            }
            catch (Exception ex) {
                throw ex;
            }
            
        }

        public bool VerificarSalaOcupada(Sessao sessao)
        {
            var sessaoDataFim = CalculaDataFim(sessao);

            var query = from se in _contexto.Sessao
                        join sa in _contexto.Sala
                        on se.Sala.Id equals sa.Id
                        join fi in _contexto.Filme
                        on se.Filme.Id equals fi.Id
                        where
                        ((se.DataInicio >= sessao.DataInicio
                        && se.DataInicio <= sessaoDataFim.DataFim) ||
                        (se.DataFim >= sessao.DataInicio
                        && se.DataFim <= sessaoDataFim.DataFim))
                        select new Sessao
                        {
                            Id = se.Id,
                            DataInicio = se.DataInicio,
                            DataFim = se.DataFim,
                            ValorIngresso = se.ValorIngresso,
                            TipoAnimacao = se.TipoAnimacao,
                            TipoAudio = se.TipoAudio,
                            FilmeId = se.FilmeId,
                            SalaId = se.SalaId,
                            Sala = sa,
                            Filme = fi
                        };

            Sessao result = query.FirstOrDefault();

            if (result == null)
                return false;

            else if (result.SalaId == sessao.SalaId && result.Filme.Id == sessao.FilmeId)
                return false;

            return true;

        }

    }
}
