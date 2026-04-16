using System;
using MediatR;

namespace Catalogo.Application.UseCases.Genero.Update;

public record UpdateGeneroInput(Guid id,string nome, string status) : IRequest<UpdateGeneroOutput>
{

}
