using System;

namespace Catalogo.Application.UseCases.Video.Common;

public record VideoModelOutput(Guid id,  string titulo, string descricao, int anoLancamento, int duracao,List<Guid> categoriasIds,List<Guid> generosIds,List<Guid> castIds,string thumbArquivoUrl, string bannerArquivoUrl, string videoArquivoUrl, string thumbHalfArquivoUrl, string trailerArquivoUrl);

