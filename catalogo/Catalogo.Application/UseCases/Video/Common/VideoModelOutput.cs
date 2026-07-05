using System;

namespace Catalogo.Application.UseCases.Video.Common;

public record VideoModelOutput(Guid id,  string titulo, string descricao, int anoLancamento, int duracao,string thumb, string banner, string media, string thumbHalf, string trailer);

