using System;
using MediatR;

namespace Catalogo.Application.UseCases.Genero.Get;

public record GetGeneroInput(int id): IRequest<GetGeneroOutput>
{

}
