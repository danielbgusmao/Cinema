using AutoMapper;
using Cinema.Domain.Entities;
using Cinema.Domain.Interfaces;
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
    public class SalaServiceImpl : ISalaService
    {
        private readonly ISalaRepository _salaRepository;
        private readonly IMapper _mapper;

        public SalaServiceImpl(ISalaRepository salaRepository, IMapper mapper)
        {
            _salaRepository = salaRepository;
            _mapper = mapper;
        }

        public Sala Insert(Sala sala)
        {
            Sala entity = _mapper.Map<Sala>(sala);

            Validate(entity, Activator.CreateInstance<SalaValidator>());

            _salaRepository.Insert(entity);

            Sala outputModel = _mapper.Map<Sala>(entity);
            return outputModel;
        }

        
        public IEnumerable<Sala> Get()
        {
            var entities = _salaRepository.Select();

            var output = entities.Select(s => _mapper.Map<Sala>(s));

            return output;
        }
        private static void Validate(Sala filme, AbstractValidator<Sala> validator)
        {
            if (filme == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(filme);
        }

        public void VerificarEPopularTabela()
        {
            var salas = _salaRepository.Select();
            if (!salas.Any())
            {
                for (int i = 1; i <= 10; i++)
                {
                    Sala sala = new()
                    {
                        Nome = "Sala " + i,
                        QuantidadeAssentos = 10 * i
                    };

                    _salaRepository.Insert(sala);
                }
            }
        }

        public Sala GetById(Guid id)
        {
            var entity = _salaRepository.GetById(id);

            var output = _mapper.Map<Sala>(entity);

            return output;
        }
    }
}
