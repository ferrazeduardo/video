using System;
using MediatR;

namespace Catalogo.Application.UseCases.Genero.AddCategoria;

public record AddCategoriaInput(Guid Id, string Nome) : IRequest<AddCategoriaOutput>
{
}
