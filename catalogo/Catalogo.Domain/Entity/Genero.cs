using System;
using Catalogo.Domain.Exceptions;
using Catalogo.Domain.SeedWork;
using Catalogo.Domain.Validation;

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

    public Genero()
    {
        
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

    public void ValidacaoUpdate()
    {
        string[] statusValidos = new string[] { "S", "N" };
        ValidadorDeRegra.Novo()
        .Quando(string.IsNullOrEmpty(Nome), "O nome do gênero é obrigatório.")
        .Quando(statusValidos.Contains(Status) is false, "Status deve ser 'S' ou 'N'")
        .DispararExcecaoSeExistirErro();
    }

    public void AddCategoria(Categoria categoria)
    {
        Categorias.Add(categoria);
    }

    public void RemoveCategoria(Categoria categoria)
    {
        Categorias.Remove(categoria);
    }

    public void AddCategoria(Guid id, string nome)
    {
        var categoria = Categorias.FirstOrDefault(x => x.idGuid == id);
        ExcecaoDeDominio.HaError(categoria is not null, "Categoria já existe nesse gênero");
        var categoriaNova = new Categoria(id, nome);
        Categorias.Add(categoriaNova);
    }

    public void Update(string nome, string status)
    {
        Nome = nome;
        Status = string.IsNullOrEmpty(status) ? Status : status;
        ValidacaoUpdate();
    }
}
