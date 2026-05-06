using System;
using Catalogo.Domain.Enum;
using MediatR;

namespace Catalogo.Application.UseCases.CastFilme.Create;

public record CreateCastFilmeInput(string nome,CastFilmeTipo tipo) : IRequest<CreateCastFilmeOutput>
{
}
