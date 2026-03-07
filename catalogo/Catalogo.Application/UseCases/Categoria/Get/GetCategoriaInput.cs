using System;
using MediatR;

namespace Catalogo.Application.UseCases.Categoria.Get;

public class GetCategoriaInput : IRequest<GetCategoriaOutput>
{
    public Guid id { get; set; }
}
