using System;
using Catalogo.Application.UseCases.Categoria.Common;
using MediatR;

namespace Catalogo.Application.UseCases.Categoria.Get;

public record GetCategoriaInput(Guid id) : IRequest<GetCategoriaOutput<CategoriaModelOutput>>
{
}
