using AutoMapper;
using Cinema.Domain.Entities;
using Cinema.Domain.Interfaces;
using Cinema.Infra.Data.Mapping;
using Cinema.Service.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Service.Services
{
    public class FilmeServiceImpl : IFilmeService
    {
        private readonly IFilmeRepository _filmeRepository;
        private readonly IMapper _mapper;

        public FilmeServiceImpl(IFilmeRepository filmeRepository, IMapper mapper)
        {
            _filmeRepository = filmeRepository;
            _mapper = mapper;
        }

        public bool Insert(Filme filme)
        {
            if (filme.Id != Guid.Empty) 
                throw new Exception("O Id do filme deve ser vazio.");

            Filme entity = _mapper.Map<Filme>(filme);

            Validate(entity, Activator.CreateInstance<FilmeValidator>());

            _filmeRepository.Insert(entity);

            Filme outputModel = _mapper.Map<Filme>(entity);

            return true;
        }

        public bool Delete(Guid id)
        {
            var filme = _filmeRepository.GetById(id);

            if (filme == null)
                throw new Exception("Filme não encontrado.");

            _filmeRepository.Delete(id);
            return true;
        }

        public IEnumerable<Filme> Get()
        {
            var entities = _filmeRepository.Select();

            var output = entities.Select(s => _mapper.Map<Filme>(s));

            return output;
        }

        public Filme GetById(Guid id)
        {
            var filme = _filmeRepository.GetById(id);

            if (filme == null) 
                throw new Exception("Filme não encontrado.");

            var output = _mapper.Map<Filme>(filme);

            return output;
        }

        public bool Update(Filme filme)
        {
            if (filme.Id == Guid.Empty)
                throw new Exception("ID inválido.");

            Filme entity = _mapper.Map<Filme>(filme);
            
            Validate(entity, Activator.CreateInstance<FilmeValidator>());
            _filmeRepository.Update(entity);

            Filme output = _mapper.Map<Filme>(entity);

            return true;
        }

        private static void Validate(Filme filme, AbstractValidator<Filme> validator)
        {
            if (filme == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(filme);
        }

        public Filme TituloEmUso(Filme filme)
        {
            if (filme.Titulo == null)
                throw new Exception("Título do filme não informado.");

            return _filmeRepository.TituloEmUso(filme);
        }
    }
}
