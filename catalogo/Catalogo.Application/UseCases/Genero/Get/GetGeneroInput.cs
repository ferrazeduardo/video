using System;
using MediatR;

namespace Catalogo.Application.UseCases.Genero.Get;

public record GetGeneroInput(Guid id): IRequest<GetGeneroOutput>
{

}
