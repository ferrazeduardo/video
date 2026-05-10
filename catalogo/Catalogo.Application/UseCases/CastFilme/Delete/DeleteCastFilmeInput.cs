using System;
using MediatR;

namespace Catalogo.Application.UseCases.CastFilme.Delete;

public record DeleteCastFilmeInput(Guid Id) : IRequest<DeleteCastFilmeOutput>
{

}
