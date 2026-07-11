using System;
using Catalogo.Domain.Enum;
using MediatR;

namespace Catalogo.Application.UseCases.Video.Update;

public record UpdateVideoInput(Guid id, string titulo, string descricao, int anoLancamento,int duracao,bool publicado,Rating rating) : IRequest<UpdateVideoOutput>;
