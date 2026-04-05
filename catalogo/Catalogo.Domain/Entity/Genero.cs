using System;
using Catalogo.Domain.Exceptions;
using Catalogo.Domain.SeedWork;

namespace Catalogo.Domain.Entity;

public class Genero : AggregationRoot
{
    public Genero(string nome)
    {
        Nome = nome;
        dataCriacao = DateTime.UtcNow;
        Validacao();
        Ativo();
    }

    public string Nome { get; private set; }
    public string Status { get; private set; }
    public DateTime dataCriacao { get; private set; }

    public ICollection<Categoria> Categorias { get; private set; } = [];

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
        Validacao();
    }



    public void Validacao()
    {
        ExcecaoDeDominio.HaError(string.IsNullOrEmpty(Nome), "O nome do gênero é obrigatório.");
    }

    public void AddCategoria(Categoria categoria)
    {
        Categorias.Add(categoria);
    }

    public void RemoveCategoria(Categoria categoria)
    {
        Categorias.Remove(categoria);
    }
}
