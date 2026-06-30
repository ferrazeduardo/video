using System;

namespace Catalogo.Application.UseCases.Video.Common;

public record ArquivoInput(string extension, Stream arquivoStream);