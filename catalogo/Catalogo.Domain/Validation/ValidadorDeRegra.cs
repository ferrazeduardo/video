using System;
using Catalogo.Domain.Exceptions;

namespace Catalogo.Domain.Validation;

public class ValidadorDeRegra
{
    public string Mensagem = "";
    public ValidadorDeRegra()
    {

    }

    public static ValidadorDeRegra Novo()
    {
        return new ValidadorDeRegra();
    }

    public ValidadorDeRegra Quando(bool temErro, string mensagem)
    {
        if (temErro)
            Mensagem = mensagem;

        return this;
    }


    public void DispararExcecaoSeExistirErro()
    {
        if (string.IsNullOrEmpty(Mensagem) is false)
            throw new ExcecaoDeDominio(Mensagem);
    }
}
