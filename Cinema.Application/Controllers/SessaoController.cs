using Cinema.Application.Commands.Sessao;
using Cinema.Application.Models;
using Cinema.Application.Queries.Sessao;
using Cinema.Domain.Entities;
using Cinema.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly Cinema.Domain.Interfaces.ISessaoService _sessaoService;
        
        public SessaoController(IMediator mediator, Cinema.Domain.Interfaces.ISessaoService sessaoService)
        {
            _mediator = mediator;
            _sessaoService = sessaoService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await Execute(async () => await _mediator.Send(new GetAllSessoesQuery()));
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return await Execute(async () => await _mediator.Send(new GetSessaoByIdQuery(id)));
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(Sessao sessao)
        {
            if (sessao == null)
                return NotFound();

            var command = new CreateSessaoCommand(
                sessao.DataInicio == default ? DateTime.Now : sessao.DataInicio,
                sessao.DataFim ?? DateTime.Now,
                sessao.ValorIngresso ?? 0,
                sessao.TipoAnimacao,
                sessao.TipoAudio,
                sessao.FilmeId,
                sessao.SalaId);

            return await Execute(async () => await _mediator.Send(command));
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update(Sessao sessao)
        {
            var command = new UpdateSessaoCommand(
                sessao.Id,
                sessao.DataInicio == default ? DateTime.Now : sessao.DataInicio,
                sessao.DataFim ?? DateTime.Now,
                sessao.ValorIngresso ?? 0,
                sessao.TipoAnimacao,
                sessao.TipoAudio,
                sessao.FilmeId,
                sessao.SalaId);

            return await Execute(async () => await _mediator.Send(command));
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await Execute(async () =>
            {
                await _mediator.Send(new DeleteSessaoCommand(id));
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

        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
