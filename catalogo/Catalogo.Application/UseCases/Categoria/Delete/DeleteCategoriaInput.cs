using System;
using MediatR;

namespace Catalogo.Application.UseCases.Categoria.Delete;

public class DeleteCategoriaInput : IRequest<DeleteCategoriaOutput>
{
    public Guid id { get; set; }
}
