using System;
using Catalogo.Application.UseCases.Categoria.Common;
using MediatR;

namespace Catalogo.Application.UseCases.Categoria.Get;

public class GetCategoriaInput : IRequest<GetCategoriaOutput<CategoriaModelOutput>>
{
    public Guid id { get; set; }
}
