using System;

namespace Catalogo.Domain.Validation;

public abstract class ValidationHandler
{
    public abstract void HandleError(ValidationError error);

    public void HandleError(string mensagem) => HandleError(new ValidationError(mensagem));

}
