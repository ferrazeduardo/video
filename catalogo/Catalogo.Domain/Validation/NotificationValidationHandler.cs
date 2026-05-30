using System;

namespace Catalogo.Domain.Validation;

public class NotificationValidationHandler : ValidationHandler
{
    private readonly List<ValidationError> _erros;

    public IReadOnlyCollection<ValidationError> Erros => _erros.AsReadOnly();

    public bool HasErros() => _erros is not null && _erros.Any();

    public NotificationValidationHandler()
    {
        _erros = new List<ValidationError>();
    }
    public override void HandleError(ValidationError error)
    {
        _erros.Add(error);
    }
}
