using System;
using Catalogo.Domain.Exceptions;
using Catalogo.Domain.SeedWork;
using Catalogo.Domain.Validation;

namespace Catalogo.Domain.Entity;

public class Categoria : AggregationRoot
{
    public Categoria(string nome, string descricao) : base()
    {
        Nome = nome;
        Descricao = descricao;
        Ativo();
        dataCriacao = DateTime.Now;
        Validacao();
    }
    public string Nome { get; private set; }
    public string Descricao { get; private set; }
    public string Status { get; private set; }
    public DateTime dataCriacao { get; private set; }

    private string[] statusValidos = { "S", "N" };


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
        .Quando(string.IsNullOrEmpty(Descricao), "Descricao não pode ser nulo")
        .Quando(Descricao.Length > 10_000, "Descricao não pode ter mais de 10.000 caracteres")
        .DispararExcecaoSeExistirErro();
    }

    public void Update(string nome, string descricao, string status)
    {
        ExcecaoDeDominio.HaError(status is not null && statusValidos.Contains(status), "Status não é válido");
        Nome = nome ?? Nome;
        Descricao = descricao ?? Descricao;
        Status = status ?? Status;
    }
}
