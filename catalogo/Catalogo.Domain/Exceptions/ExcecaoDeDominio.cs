using System;
using Catalogo.Domain.Validation;

namespace Catalogo.Domain.Exceptions;

public class ExcecaoDeDominio : Exception
{
    public IReadOnlyCollection<ValidationError>? _erros { get; }
    public ExcecaoDeDominio(string mensagem) : base(mensagem)
    {

    }


    public ExcecaoDeDominio(string? mensagem, IReadOnlyCollection<ValidationError>? errors = null) : base(mensagem)
    {
        _erros = errors;
    }

    internal static void HaError(bool regra, string mensagem)
    {
        if (regra)
            throw new ExcecaoDeDominio(mensagem);
    }
}
