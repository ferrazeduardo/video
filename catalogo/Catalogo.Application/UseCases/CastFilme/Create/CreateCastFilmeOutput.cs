using System;

namespace Catalogo.Application.UseCases.CastFilme.Create;

public class CreateCastFilmeOutput
{
    private Guid idGuid;

    public CreateCastFilmeOutput(Guid idGuid)
    {
        this.idGuid = idGuid;
    }
}
