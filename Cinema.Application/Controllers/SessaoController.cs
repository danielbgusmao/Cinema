using Cinema.Application.Models;
using Cinema.Domain.Entities;
using Cinema.Domain.Interfaces;
using Cinema.Service.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Web.Http.Cors;
using Cinema.Domain.Models;


namespace Cinema.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private readonly ISessaoService _sessaoService;
        
        public SessaoController(ISessaoService sessaoService)
        {
            _sessaoService = sessaoService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _sessaoService.Get());
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            return Execute(() => _sessaoService.GetById(id));
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create(Sessao sessao)
        {
            if (sessao == null)
                return NotFound();

            var retorno = Execute(() => _sessaoService.Insert(sessao));

            return retorno;
        }

        [Authorize]
        [HttpPut]
        public IActionResult Update(Sessao sessao)
        {
            return Execute(() => _sessaoService.Update(sessao));
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {

            Execute(() =>
            {
                _sessaoService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize]
        [Route("CalculaDataFim")]
        [HttpPost]
        public IActionResult CalculaDataFim(SessaoSugestaoViewModel sessaoViewModel)
        {
            var sessao = new Sessao()
            {
                FilmeId = sessaoViewModel.FilmeId,
                SalaId = sessaoViewModel.SalaId,
                DataInicio = sessaoViewModel.DataInicio
            };
            return Execute(() => _sessaoService.CalculaDataFim(sessao));
        }

        [Authorize]
        [Route("SugestaoDataInicio")]
        [HttpPost]
        public IActionResult SugestaoDataInicio(SessaoSugestaoViewModel sessaoViewModel)
        {
            var sessao = new Sessao()
            {
                FilmeId = sessaoViewModel.FilmeId,
                SalaId = sessaoViewModel.SalaId,
                DataInicio = sessaoViewModel.DataInicio
            };
            return Execute(() => _sessaoService.SugestaoDataInicio(sessao));
        }

        [Authorize]
        [Route("VerificarSalaOcupada")]
        [HttpPost]
        public IActionResult VerificarSalaOcupada(SessaoSugestaoViewModel sessaoViewModel)
        {
            var sessao = new Sessao()
            {
                FilmeId = sessaoViewModel.FilmeId,
                SalaId = sessaoViewModel.SalaId,
                DataInicio = sessaoViewModel.DataInicio
            };
            return Execute(() => _sessaoService.VerificarSalaOcupada(sessao));
        }

        [Authorize]
        [Route("ValidaDeleteSessao")]
        [HttpPost]
        public IActionResult ValidaDeleteSessao(Sessao sessao)
        {
           return Execute(() => _sessaoService.ValidaDeleteSessao(sessao));
        }
    }
}
