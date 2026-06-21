using System;
using MediatR;

namespace Catalogo.Application.UseCases.Video.AddGenero;

public record AddGeneroInput(Guid idVideo, Guid idGenero) : IRequest<AddGeneroOutput>
{

}
