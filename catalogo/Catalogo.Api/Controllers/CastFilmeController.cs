using Catalogo.Application.UseCases.CastFilme.Create;
using Catalogo.Application.UseCases.CastFilme.Delete;
using Catalogo.Application.UseCases.CastFilme.Get;
using Catalogo.Application.UseCases.CastFilme.Update;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CastFilmeController : ControllerBase
    {
        private IMediator _mediator;

        public CastFilmeController(IMediator mediator)
        {
            _mediator = mediator;
        }

  [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCastFilmeInput createCastFilmeInput, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(createCastFilmeInput, cancellationToken);
            return Ok(response);
        }

        [HttpPost("obter")]
        public async Task<IActionResult> Get([FromBody] GetCastFilmeInput getCastFilmeInput, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(getCastFilmeInput, cancellationToken);
            return Ok(response);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteCastFilmeInput deleteCastFilmeInput, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(deleteCastFilmeInput, cancellationToken);
            return Ok(response);
        }


        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateCastFilmeInput updateCastFilmeInput, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(updateCastFilmeInput, cancellationToken);
            return Ok(response);    
        }

    }
}
