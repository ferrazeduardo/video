using System;
using MediatR;

namespace Catalogo.Application.UseCases.Video.AddCategoria;

public record AddCategoriaInput(Guid idVideo , List<Guid> idCategoria) : IRequest<AddCategoriaOuput>
{
    
}
