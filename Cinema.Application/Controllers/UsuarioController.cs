using Cinema.Application.Commands.Usuario;
using Cinema.Application.Models;
using Cinema.Application.Queries.Usuario;
using Cinema.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Usuario usuario)
        {
            if (usuario.Id != Guid.Empty)
                throw new Exception("UserID must be empty");

            var command = new CreateUsuarioCommand(usuario.Nome, usuario.Email, usuario.Senha);
            return await Execute(async () => await _mediator.Send(command));
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Usuario usuario)
        {
            var command = new UpdateUsuarioCommand(usuario.Id, usuario.Nome, usuario.Email, usuario.Senha);
            return await Execute(async () => await _mediator.Send(command));
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await Execute(async () =>
            {
                await _mediator.Send(new DeleteUsuarioCommand(id));
                return true;
            });

            return new NoContentResult();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await Execute(async () => await _mediator.Send(new GetAllUsuariosQuery()));
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return await Execute(async () => await _mediator.Send(new GetUsuarioByIdQuery(id)));
        }

        private async Task<IActionResult> Execute(Func<Task<object>> func)
        {
            try
            {
                var result = await func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
