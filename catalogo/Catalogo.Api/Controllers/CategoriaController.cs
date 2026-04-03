using Catalogo.Application.UseCases.Categoria.Create;
using Catalogo.Application.UseCases.Categoria.Delete;
using Catalogo.Application.UseCases.Categoria.Get;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private IMediator _mediator;

        public CategoriaController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoriaInput createCategoriaInput, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(createCategoriaInput, cancellationToken);
            return Ok(response);
        }

        [HttpPost("obter")]
        public async Task<IActionResult> Get([FromBody] GetCategoriaInput getCategoriaInput, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(getCategoriaInput, cancellationToken);
            return Ok(response);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteCategoriaInput deleteCategoriaInput, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(deleteCategoriaInput, cancellationToken);
            return Ok(response);
        }


        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] CreateCategoriaInput createCategoriaInput, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(createCategoriaInput, cancellationToken);
            return Ok(response);    
        }
    }
}
