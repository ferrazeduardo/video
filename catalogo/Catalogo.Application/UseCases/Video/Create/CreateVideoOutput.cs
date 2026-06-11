using Catalogo.Domain.Enum;

namespace Catalogo.Application.UseCases.Video.Create;

public record  CreateVideoOutput(
    Guid id,
    String titulo,
    String descricao,
    int duracao,
    Rating rating,
    int anoLancamento,
    bool publicado
)
{

}
