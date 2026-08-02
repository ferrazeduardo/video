using System;
using MediatR;

namespace Catalogo.Application.UseCases.Video.AddCast;

public record AddCastInput(int idVideio, List<int> idCastFilme) : IRequest<AddCastOutput>
{

}
