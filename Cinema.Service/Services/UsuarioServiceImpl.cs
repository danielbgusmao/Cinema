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
    public class UsuarioServiceImpl : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioServiceImpl(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public Usuario GetByEmailSenha(string email, string senha)
        {
            var entity = _usuarioRepository.GetByEmailSenha(email, senha);

            var output = _mapper.Map<Usuario>(entity);

            return output;
        }

        public Usuario Insert(Usuario usuario)
        {
            Usuario entity = _mapper.Map<Usuario>(usuario);

            Validate(entity, Activator.CreateInstance<UsuarioValidator>());

            _usuarioRepository.Insert(entity);

            Usuario outputModel = _mapper.Map<Usuario>(entity);

            return outputModel;
        }

        public void Delete(Guid id) => _usuarioRepository.Delete(id);

        public IEnumerable<Usuario> Get()
        {
            var entities = _usuarioRepository.Select();

            var output = entities.Select(s => _mapper.Map<Usuario>(s));
            return output;
        }

        public Usuario GetById(Guid id)
        {
            var entity = _usuarioRepository.GetById(id);

            var output = _mapper.Map<Usuario>(entity);

            return output;
        }

        public Usuario Update(Usuario usuario)
        {
            Usuario entity = _mapper.Map<Usuario>(usuario);

            Validate(entity, Activator.CreateInstance<UsuarioValidator>());
            _usuarioRepository.Update(entity);

            Usuario output = _mapper.Map<Usuario>(entity);

            return output;
        }

        private static void Validate(Usuario usuario, AbstractValidator<Usuario> validator)
        {
            if (usuario == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(usuario);
        }


    }
}
