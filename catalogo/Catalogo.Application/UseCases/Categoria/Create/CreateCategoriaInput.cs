using System;
using MediatR;

namespace Catalogo.Application.UseCases.Categoria.Create;

public record CreateCategoriaInput(string nome,string descricao) : IRequest<CreateCategoriaOutput>
{
}
