using AutoMapper;
using Cinema.Domain.Entities;
using Cinema.Domain.Interfaces;
using Cinema.Service.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Application.Tests.Services
{
    public class FilmeServiceTests
    {
        private readonly FilmeServiceImpl filmeService;

        public FilmeServiceTests() 
        {
            filmeService = new FilmeServiceImpl(new Mock<IFilmeRepository>().Object, new Mock<IMapper>().Object);
        }

        [Fact]
        public void Post_EnviandoIdValido()
        {
            var exeption = Assert.Throws<Exception>(() => filmeService.Insert(new Filme { Id = Guid.NewGuid() }));
            Assert.Equal("O Id do filme deve ser vazio.", exeption.Message);
        }

        [Fact]
        public void Get_GetByIdEnviandoGuidQualquer()
        {
            var guid = Guid.NewGuid();
            var exception = Assert.Throws<Exception>(() => filmeService.GetById(guid));
            Assert.Equal("Filme não encontrado.", exception.Message);
        }

        [Fact]
        public void Put_EnviandoGuidVazio()
        {
            var exception = Assert.Throws<Exception>(() => filmeService.Update(new Filme()));
            Assert.Equal("ID inválido.", exception.Message);
        }

        [Fact]
        public void Put_EnviandoFilmeComGuidQualquer()
        {
            var guid = Guid.NewGuid();
            var exception = Assert.Throws<Exception>(() => filmeService.Update(new Filme() { Id = guid}));
            Assert.Equal("Registros não detectados!", exception.Message);
        }

        [Fact]
        public void Delete_EnviandoGuidQualquer()
        {
            var exception = Assert.Throws<Exception>(() => filmeService.Delete(Guid.NewGuid()));
            Assert.Equal("Filme não encontrado.", exception.Message);
        }

        [Fact]
        public void TituloEmUsoTest()
        {
            var exception = Assert.Throws<Exception>(() => filmeService.TituloEmUso(new Filme()));
            Assert.Equal("Título do filme não informado.", exception.Message);
        }

        [Fact]
        public void Post_VerificarSeTituloEstaEmUso()
        {
            Filme filme = new()
            {
                Titulo = "Título teste",
                Descricao = "Descrição teste",
                Duracao = "01:40"
            };

            var filmeTituloEmUso = filmeService.TituloEmUso(filme);
            Assert.Null(filmeTituloEmUso);
        }

    }
}
