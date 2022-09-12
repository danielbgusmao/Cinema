using AutoMapper;
using Cinema.Domain.Entities;
using Cinema.Domain.Interfaces;
using Cinema.Infra.Data.Repository;
using Cinema.Service.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Application.Tests.Services
{
    public class SessaoServiceTests
    {
        private readonly SessaoServiceImpl sessaoService;

        public SessaoServiceTests()
        {
            sessaoService = new SessaoServiceImpl(new Mock<ISessaoRepository>().Object, new Mock<IFilmeRepository>().Object, new Mock<IMapper>().Object);
        }

        [Fact]
        public void Post_EnviandoIdValido()
        {
            var exeption = Assert.Throws<Exception>(() => sessaoService.Insert(new Sessao { Id = Guid.NewGuid() }));
            Assert.Equal("O Id da sessao deve ser vazio.", exeption.Message);
        }

        [Fact]
        public void Get_GetByIdEnviandoGuidQualquer()
        {
            var guid = Guid.NewGuid();
            var exception = Assert.Throws<Exception>(() => sessaoService.GetById(guid));
            Assert.Equal("Sessão não encontrada.", exception.Message);
        }

        [Fact]
        public void Put_EnviandoGuidVazio()
        {
            var exception = Assert.Throws<Exception>(() => sessaoService.Update(new Sessao()));
            Assert.Equal("ID inválido.", exception.Message);
        }

        [Fact]
        public void Put_EnviandoFilmeComGuidQualquer()
        {
            var guid = Guid.NewGuid();
            var exception = Assert.Throws<Exception>(() => sessaoService.Update(new Sessao() { Id = guid }));
            Assert.Equal("Registros não detectados!", exception.Message);
        }

        [Fact]
        public void Delete_EnviandoGuidQualquer()
        {
            var exception = Assert.Throws<Exception>(() => sessaoService.Delete(Guid.NewGuid()));
            Assert.Equal("Sessão não encontrada.", exception.Message);
        }


        [Fact]
        public void Validacoes_CalculaDataFim_SessaoNull()
        {
            Sessao sessao = null;

            var exception = Assert.Throws<Exception>(() => sessaoService.CalculaDataFim(sessao));
            Assert.Equal("Sessão não pode ser null.", exception.Message);
        }

        [Fact]
        public void Validacoes_CalculaDataFim_SessaoQualquer()
        {
            Sessao sessao = new()
            {
                FilmeId = Guid.NewGuid(),
                DataInicio = DateTime.Now,
                Id = Guid.NewGuid()
            };

            var result = sessaoService.CalculaDataFim(sessao);
            Assert.Null(result);
        }

        [Fact]
        public void Validacoes_VerificarSalaOcupada_SessaoQualquer()
        {
            Sessao sessao = new()
            {
                FilmeId = Guid.NewGuid(),
                DataInicio = DateTime.Now,
                Id = Guid.NewGuid()
            };

            var result = sessaoService.VerificarSalaOcupada(sessao);
            Assert.False(result);
        }

        [Fact]
        public void Validacoes_SugestaoDataInicio_SessaoNull()
        {
            Sessao sessao = null;

            var exception = Assert.Throws<Exception>(() => sessaoService.SugestaoDataInicio(sessao));
            Assert.Equal("Sessão não pode ser null.", exception.Message);
        }

        [Fact]
        public void Validacoes_SugestaoDataInicio_SessaoQualquer()
        {
            Sessao sessao = new()
            {
                FilmeId = Guid.NewGuid(),
                DataInicio = DateTime.Now,
                Id = Guid.NewGuid()
            };

            var result = sessaoService.SugestaoDataInicio(sessao);
            Assert.Null(result);
        }

        [Fact]
        public void Validacoes_ValidaDeleteSessao_SessaoQualquer()
        {
            Sessao sessao = new()
            {
                FilmeId = Guid.NewGuid(),
                DataInicio = DateTime.Now,
                Id = Guid.NewGuid()
            };

            var result = sessaoService.ValidaDeleteSessao(sessao);
            Assert.False(result);
        }


    }
}
