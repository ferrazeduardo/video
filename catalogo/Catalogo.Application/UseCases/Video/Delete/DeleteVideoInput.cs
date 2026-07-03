using System;
using MediatR;

namespace Catalogo.Application.UseCases.Video.Delete;

public record DeleteVideoInput(int id) : IRequest<DeleteVideoOutput>;
