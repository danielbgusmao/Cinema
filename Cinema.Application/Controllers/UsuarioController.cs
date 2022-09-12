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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [Authorize]
        [HttpPost]
        public IActionResult Create([FromBody] Usuario usuario)
        {
            if (usuario.Id != Guid.Empty)
                throw new Exception("UserID must be empty");

            return Execute(() => _usuarioService.Insert(usuario));
        }

        [Authorize]
        [HttpPut]
        public IActionResult Update([FromBody] Usuario usuario)
        {
            return Execute(() => _usuarioService.Update(usuario));
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            Execute(() =>
            {
                _usuarioService.Delete(id);
                return true;
            });

            return new NoContentResult();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            return Execute(() => _usuarioService.Get());
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return Execute(() => _usuarioService.GetById(id));
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
