using System;
using MediatR;

namespace Catalogo.Application.UseCases.Video.VincularGenero;

public record VincularGeneroInput(Guid idVideo, Guid idGenero) : IRequest<VincularGeneroOutput>
{

}
