using System;
using Catalogo.Domain.Enum;
using MediatR;

namespace Catalogo.Application.UseCases.CastFilme.Update;

public record UpdateCastFilmeInput(Guid id, string nome, CastFilmeTipo tipo) : IRequest<UpdateCastFilmeOutput>
{

}
