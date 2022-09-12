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

namespace Cinema.Application.Controllers
{
    [EnableCors("*","*","*")]
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeService _filmeService;
        
        public FilmeController(IFilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _filmeService.Get());
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return Execute(() => _filmeService.GetById(id));
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post(Filme filme)
        {
            return Execute(() => _filmeService.Insert(filme));
        }

        [Authorize]
        [Route("TituloEmUso")]
        [HttpPost]
        public IActionResult TituloEmUso(FilmeTituloEmUsoViewModel filmeTituloEmUso)
        {
            Filme filme = new()
            {
                Id = filmeTituloEmUso.Id,
                Titulo = filmeTituloEmUso.Titulo
            };

            return Execute(() => _filmeService.TituloEmUso(filme));
        }

        [Authorize]
        [HttpPut]
        public IActionResult Put(Filme filme)
        {
            return Execute(() => _filmeService.Update(filme));
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            Execute(() =>
            {
                _filmeService.Delete(id);
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
    }
}
