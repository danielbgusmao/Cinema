using Cinema.Application.Models;
using Cinema.Domain.Entities;
using Cinema.Domain.Interfaces;
using Cinema.Service.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Cinema.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalaController : ControllerBase
    {
        private readonly ISalaService _salaService;

        public SalaController(ISalaService salaService)
        {
            _salaService = salaService;
        }


        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            _salaService.VerificarEPopularTabela();
            return Execute(() => _salaService.Get());
        }


        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            return Execute(() => _salaService.GetById(id));
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
