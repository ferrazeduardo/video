using System;

namespace Catalogo.Domain.Exceptions;

public class ExcecaoDeDominio : Exception
{
    public ExcecaoDeDominio(string mensagem) : base(mensagem)
    {
        
    }

    
}
