using AutoMapper;
using Cinema.Domain.Entities;
using Cinema.Domain.Interfaces;
using Cinema.Domain.Models;
using Cinema.Infra.Data.Mapping;
using Cinema.Infra.Data.Repository;
using Cinema.Service.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Cinema.Service.Services
{
    public class SessaoServiceImpl : ISessaoService
    {
        private readonly ISessaoRepository _sessaoRepository;
        private readonly IFilmeRepository _filmeRepository;
        private readonly IMapper _mapper;

        public SessaoServiceImpl(ISessaoRepository sessaoRepository, IFilmeRepository filmeRepository, IMapper mapper)
        {
            _sessaoRepository = sessaoRepository;
            _filmeRepository = filmeRepository;
            _mapper = mapper;
        }

        public Sessao Insert(Sessao sessao)
        {
            if (sessao.Id != Guid.Empty)
                throw new Exception("O Id da sessao deve ser vazio.");

            Sessao entity = _mapper.Map<Sessao>(sessao);

            Validate(entity, Activator.CreateInstance<SessaoValidator>());

            _sessaoRepository.Insert(entity);

            Sessao outputModel = _mapper.Map<Sessao>(entity);

            return outputModel;
        }

        public void Delete(Guid id)
        {
            Sessao sessao = GetById(id);

            if (sessao == null)
                throw new Exception("Sessão não encontrada.");

            if (ValidaDeleteSessao(sessao))
            {
                _sessaoRepository.Delete(id);
            }
        }

        public IEnumerable<Sessao> Get()
        {
            var entities = _sessaoRepository.Select();

            var output = entities.Select(s => _mapper.Map<Sessao>(s));

            return output;
        }

        public Sessao GetById(Guid id)
        {
            var entity = _sessaoRepository.GetById(id);

            if (entity == null)
                throw new Exception("Sessão não encontrada.");

            var output = _mapper.Map<Sessao>(entity);

            return output;
        }

        public Sessao Update(Sessao sessao)
        {
            if (sessao.Id == Guid.Empty)
                throw new Exception("ID inválido.");

            Sessao entity = _mapper.Map<Sessao>(sessao);

            Validate(entity, Activator.CreateInstance<SessaoValidator>());
            _sessaoRepository.Update(entity);

            Sessao output = _mapper.Map<Sessao>(entity);

            return output;
        }

        private static void Validate(Sessao sessao, AbstractValidator<Sessao> validator)
        {
            if (sessao == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(sessao);
        }

        public Sessao CalculaDataFim(Sessao sessao)
        {
            if (sessao == null)
                throw new Exception("Sessão não pode ser null.");

            return _sessaoRepository.CalculaDataFim(sessao);
        }

        public List<SessaoSugestaoDataInicioViewModel> SugestaoDataInicio(Sessao sessao)
        {
            if (sessao == null)
                throw new Exception("Sessão não pode ser null.");

            return _sessaoRepository.SugestaoDataInicio(sessao, Settings.Database.SqlServer).Result;
        }

        public bool VerificarSalaOcupada(Sessao sessao)
        {
            if (sessao == null)
                throw new Exception("Sessão não pode ser null.");

            return _sessaoRepository.VerificarSalaOcupada(sessao);
        }

        public bool ValidaDeleteSessao(Sessao sessao)
        {
            DateTime hoje = DateTime.Now;
            TimeSpan diferenca = Convert.ToDateTime(sessao.DataInicio) - Convert.ToDateTime(hoje);
            int dias = diferenca.Days;
            if (dias >= 10)
                return true;
            return false;
        }
    }
}
