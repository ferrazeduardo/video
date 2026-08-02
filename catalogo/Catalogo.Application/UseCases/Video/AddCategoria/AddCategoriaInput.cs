using System;
using MediatR;

namespace Catalogo.Application.UseCases.Video.AddCategoria;

public record AddCategoriaInput(int idVideo , List<int> idCategoria) : IRequest<AddCategoriaOuput>
{
    
}
