using System;
using MediatR;

namespace Catalogo.Application.UseCases.Genero.Delete;

public record DeleteGeneroInput(int id) : IRequest<DeleteGeneroOutput>
{

}
