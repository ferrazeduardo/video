using System;

namespace Catalogo.Application.UseCases.Video.Common;

public record VideoModelOutput(
        Guid id,
        string titulo,
        string descricao,
        int anoLancamento,
        int duracao,
        List<RelatedAgreggation> categorias,
        List<RelatedAgreggation> generos,
        List<RelatedAgreggation> cast,
        string thumbArquivoUrl,
        string bannerArquivoUrl,
        string videoArquivoUrl,
        string thumbHalfArquivoUrl,
        string trailerArquivoUrl);

public record RelatedAgreggation(Guid id, string? Nome);

