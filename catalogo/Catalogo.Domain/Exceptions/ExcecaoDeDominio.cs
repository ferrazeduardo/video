using System;

namespace Catalogo.Domain.Exceptions;

public class ExcecaoDeDominio : Exception
{
    public ExcecaoDeDominio(string mensagem) : base(mensagem)
    {

    }

    internal static void HaError(bool regra, string mensagem)
    {
        if (regra)
            throw new ExcecaoDeDominio(mensagem);
    }
}
