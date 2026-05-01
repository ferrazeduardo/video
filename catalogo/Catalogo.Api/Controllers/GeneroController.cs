using Catalogo.Application.UseCases.Genero.Create;
using Catalogo.Application.UseCases.Genero.Delete;
using Catalogo.Application.UseCases.Genero.Get;
using Catalogo.Application.UseCases.Genero.List;
using Catalogo.Application.UseCases.Genero.Update;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        private IMediator _mediator;

        public GeneroController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateGeneroInput createGeneroInput, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(createGeneroInput);
            return Ok(response);
        }

        [HttpPost("obter")]
        public async Task<IActionResult> Get([FromBody] GetGeneroInput getGeneroInput)
        {
            var response = await _mediator.Send(getGeneroInput);
            return Ok(response);
        }

        [HttpPost("listar")]
        public async Task<IActionResult> List([FromBody] ListGeneroInput listGeneroInput)
        {
             var response = await _mediator.Send(listGeneroInput);
            return Ok(response);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteGeneroInput deleteGeneroInput, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(deleteGeneroInput, cancellationToken);
            return Ok(response);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateGeneroInput updateGeneroInput,CancellationToken cancellationToken)
        {
             var response = await _mediator.Send(updateGeneroInput, cancellationToken);
            return Ok(response);
        }
    }
}
