using Catalogo.Application.UseCases.Categoria.Create;
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
    }
}
