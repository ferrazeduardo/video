using System;
using MediatR;

namespace Catalogo.Application.UseCases.Video.AddGenero;

public record AddGeneroInput(int videoId, List<int> generoId) : IRequest<AddGeneroOutput>
{

}
