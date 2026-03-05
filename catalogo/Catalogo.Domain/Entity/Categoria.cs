using System;

namespace Catalogo.Domain.Entity;

public class Categoria
{
    public Categoria(string nome, string descricao)
    {
        Nome = nome;
        Descricao = descricao;
        Ativo();
        dataCriacao = DateTime.Now;
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
}
