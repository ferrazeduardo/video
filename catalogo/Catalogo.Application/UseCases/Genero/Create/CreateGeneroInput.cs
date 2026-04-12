using System;
using MediatR;

namespace Catalogo.Application.UseCases.Genero.Create;

public record CreateGeneroInput(string nome) : IRequest<CreateGeneroOutput>
{
}
