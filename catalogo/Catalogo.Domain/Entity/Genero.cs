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

    public List<int> categoriasId { get; private set; } = [];
    public ICollection<GenerosCategorias> _categorias { get; private set; } = [];

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

    public void Update(string nome, string status)
    {
        Nome = nome;
        Status = string.IsNullOrEmpty(status) ? Status : status;
        ValidacaoUpdate();
    }
}
