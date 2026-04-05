using System;
using Catalogo.Domain.SeedWork;

namespace Catalogo.Domain.Entity;

public class Genero : AggregationRoot
{
    public Genero(string nome)
    {
        Nome = nome;
        dataCriacao = DateTime.UtcNow;
        Ativo();
    }

    public string Nome { get; private set; }
    public string Status { get; private set; }
    public DateTime dataCriacao { get; private set; }

    public void Ativo()
    {
        Status = "S";
    }

    public void Inativo()
    {
        Status = "N";
    }

    public void Update(string nome)
    {
        Nome = nome;
    }
}
