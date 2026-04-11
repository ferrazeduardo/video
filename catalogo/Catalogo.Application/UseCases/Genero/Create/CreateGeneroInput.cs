using System;
using MediatR;

namespace Catalogo.Application.UseCases.Genero.Create;

public class CreateGeneroInput : IRequest<CreateGeneroOutput>
{
    public string nome { get; set; }
}
