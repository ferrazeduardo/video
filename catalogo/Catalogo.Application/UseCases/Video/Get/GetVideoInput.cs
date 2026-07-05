using System;
using MediatR;

namespace Catalogo.Application.UseCases.Video.Get;

public record GetVideoInput(Guid id) : IRequest<GetVideoOutput>;
