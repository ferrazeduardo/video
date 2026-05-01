using Catalogo.Application.UseCases.Genero.Get;
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


        [HttpPost("obter")]
        public async Task<IActionResult> Get([FromBody] GetGeneroInput getGeneroInput)
        {
            var response = await _mediator.Send(getGeneroInput);
            return Ok(response);
        }
    }
}
