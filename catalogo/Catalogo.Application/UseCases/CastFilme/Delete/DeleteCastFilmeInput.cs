using System;
using MediatR;

namespace Catalogo.Application.UseCases.CastFilme.Delete;

public record DeleteCastFilmeInput(int Id) : IRequest<DeleteCastFilmeOutput>
{

}
