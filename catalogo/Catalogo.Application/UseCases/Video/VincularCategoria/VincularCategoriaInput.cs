using System;
using MediatR;

namespace Catalogo.Application.UseCases.Video.VincularCategoria;

public record VincularCategoriaInput(Guid idVideo , Guid idCategoria) : IRequest<VincularCategoriaOuput>
{
    
}
