using Cinema.Application.Commands.Filme;
using Cinema.Application.Models;
using Cinema.Application.Queries.Filme;
using Cinema.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Cors;

namespace Cinema.Application.Controllers
{
    [EnableCors("*","*","*")]
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public FilmeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await Execute(async () => await _mediator.Send(new GetAllFilmesQuery()));
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return await Execute(async () => await _mediator.Send(new GetFilmeByIdQuery(id)));
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post(Filme filme)
        {
            var command = new CreateFilmeCommand(filme.Titulo, filme.Imagem, filme.Descricao, filme.Duracao);
            return await Execute(async () => await _mediator.Send(command));
        }

        [Authorize]
        [Route("TituloEmUso")]
        [HttpPost]
        public async Task<IActionResult> TituloEmUso(FilmeTituloEmUsoViewModel filmeTituloEmUso)
        {
            var command = new VerificarFilmeTituloEmUsoCommand(filmeTituloEmUso.Id, filmeTituloEmUso.Titulo);
            return await Execute(async () => await _mediator.Send(command));
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Put(Filme filme)
        {
            var command = new UpdateFilmeCommand(filme.Id, filme.Titulo, filme.Imagem, filme.Descricao, filme.Duracao);
            return await Execute(async () => await _mediator.Send(command));
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await Execute(async () =>
            {
                await _mediator.Send(new DeleteFilmeCommand(id));
                return true;
            });

            return new NoContentResult();
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
