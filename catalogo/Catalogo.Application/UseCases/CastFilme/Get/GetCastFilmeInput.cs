using System;
using Catalogo.Application.UseCases.CastFilme.Common;
using MediatR;

namespace Catalogo.Application.UseCases.CastFilme.Get;

public record GetCastFilmeInput(int id) : IRequest<GetCastFilmeOutput>
{

}
