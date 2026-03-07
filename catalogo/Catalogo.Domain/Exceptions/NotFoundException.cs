using System;

namespace Catalogo.Domain.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string mensagem) : base(mensagem)
    {

    }

    public static void Object(object @object, string mensagem)
    {
        if (@object is null)
            throw new NotFoundException(mensagem);
    }

    public static void List(List<object> @object, string mensagem)
    {
        if (@object.Count == 0)
            throw new NotFoundException(mensagem);
    }
}
