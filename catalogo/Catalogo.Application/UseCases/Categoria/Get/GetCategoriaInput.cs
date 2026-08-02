using System;
using Catalogo.Application.UseCases.Categoria.Common;
using MediatR;

namespace Catalogo.Application.UseCases.Categoria.Get;

public record GetCategoriaInput(int id) : IRequest<GetCategoriaOutput<CategoriaModelOutput>>
{
}
