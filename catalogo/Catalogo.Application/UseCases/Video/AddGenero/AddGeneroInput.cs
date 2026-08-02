using System;
using MediatR;

namespace Catalogo.Application.UseCases.Video.AddGenero;

public record AddGeneroInput(Guid videoId, List<int> generoId) : IRequest<AddGeneroOutput>
{

}
