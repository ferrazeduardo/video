using System;
using MediatR;

namespace Catalogo.Application.UseCases.Video.Get;

public record GetVideoInput(int id) : IRequest<GetVideoOutput>;
