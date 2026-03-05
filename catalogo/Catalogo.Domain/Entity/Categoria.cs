using System;
using Catalogo.Domain.Validation;

namespace Catalogo.Domain.Entity;

public class Categoria
{
    public Categoria(string nome, string descricao)
    {
        Nome = nome;
        Descricao = descricao;
        Ativo();
        dataCriacao = DateTime.Now;
        Validacao();
    }
    public int id { get; set; }
    public string Nome { get; private set; }
    public string Descricao { get; private set; }
    public string Status { get; private set; }
    public DateTime dataCriacao { get; private set; }


    public void Ativo()
    {
        Status = "S";
    }

    public void Desativar()
    {
        Status = "N";
    }
    public void Validacao()
    {
        ValidadorDeRegra.Novo()
        .Quando(string.IsNullOrEmpty(Nome), "Nome não pode ser nulo")
        .Quando(Nome.Length > 255, "Nome não pode ter mais de 255 caracteres")
        .Quando(Nome.Length < 3, "Nome não pode ter menos de 3 caracteres")
        .Quando(string.IsNullOrEmpty(Descricao),"Descricao não pode ser nulo")
        .Quando(Descricao.Length > 10_000,"Descricao não pode ter mais de 10.000 caracteres")
        .DispararExcecaoSeExistirErro();
    }
}
