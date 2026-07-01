using Catalogo.Application.UseCases.Video.Common;
using Catalogo.Domain.Enum;
using MediatR;

namespace Catalogo.Application.UseCases.Video.Create;

public record  CreateVideoInput(
    String titulo,
    String descricao,
    int anoLancamento,
    int duracao,
    Rating rating,
    bool publicado,
    ArquivoInput? thumb,
    ArquivoInput? banner,
    ArquivoInput? thumbHalf
) : IRequest<CreateVideoOutput>
{

}
