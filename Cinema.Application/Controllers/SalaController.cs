using Cinema.Application.Queries.Sala;
using Cinema.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalaController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ISalaService _salaService;

        public SalaController(IMediator mediator, ISalaService salaService)
        {
            _mediator = mediator;
            _salaService = salaService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _salaService.VerificarEPopularTabela();
            return await Execute(async () => await _mediator.Send(new GetAllSalasQuery()));
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return await Execute(async () => await _mediator.Send(new GetSalaByIdQuery(id)));
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
