using System;
using MediatR;

namespace Catalogo.Application.UseCases.Genero.Update;

public record UpdateGeneroInput(int id,string nome, string status) : IRequest<UpdateGeneroOutput>
{

}
