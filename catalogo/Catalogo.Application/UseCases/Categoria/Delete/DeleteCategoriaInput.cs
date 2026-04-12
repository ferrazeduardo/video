using System;
using MediatR;

namespace Catalogo.Application.UseCases.Categoria.Delete;

public record DeleteCategoriaInput(Guid id) : IRequest<DeleteCategoriaOutput>
{
}
