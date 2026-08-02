using System;
using MediatR;

namespace Catalogo.Application.UseCases.Genero.AddCategoria;

public record AddCategoriaInput(int Id, string Nome) : IRequest<AddCategoriaOutput>
{
}
