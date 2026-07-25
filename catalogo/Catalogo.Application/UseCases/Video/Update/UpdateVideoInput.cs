using System;
using Catalogo.Application.UseCases.Video.Common;
using Catalogo.Domain.Enum;
using MediatR;

namespace Catalogo.Application.UseCases.Video.Update;

public record UpdateVideoInput(
    Guid id,
    string titulo,
    string descricao, 
    int anoLancamento,
    int duracao,
    bool publicado,
    Rating rating,
    ArquivoInput banner = null,
    ArquivoInput thumb = null,
    ArquivoInput thumbHalf = null,
    List<Guid>? generosIds = null) : IRequest<UpdateVideoOutput>;
