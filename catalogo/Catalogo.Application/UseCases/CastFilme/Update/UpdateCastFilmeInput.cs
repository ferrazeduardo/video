using System;
using Catalogo.Domain.Enum;
using MediatR;

namespace Catalogo.Application.UseCases.CastFilme.Update;

public record UpdateCastFilmeInput(int id, string nome, CastFilmeTipo tipo) : IRequest<UpdateCastFilmeOutput>
{

}
