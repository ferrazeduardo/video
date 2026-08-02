using System;
using MediatR;

namespace Catalogo.Application.UseCases.Categoria.Delete;

public record DeleteCategoriaInput(int id) : IRequest<DeleteCategoriaOutput>
{
}
