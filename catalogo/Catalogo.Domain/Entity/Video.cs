using System;
using Catalogo.Domain.Enum;
using Catalogo.Domain.Exceptions;
using Catalogo.Domain.SeedWork;
using Catalogo.Domain.Validation;
using Catalogo.Domain.Validatiors;

namespace Catalogo.Domain.Entity;

public class Video : AggregationRoot
{
    public Video(string titulo, string descricao, bool publicado, int duracao, int anoLancamento,Rating rating)
    {
        Titulo = titulo;
        Descricao = descricao;
        Publicado = publicado;
        DataCriacao = DateTime.Now;
        Duracao = duracao;
        AnoLancamento = anoLancamento;
        Rating = rating;
    }

    public string Titulo { get; private set; }
    public string Descricao { get; private set; }
    public bool Publicado { get; private set; }
    public DateTime DataCriacao { get; private set; }
    public int Duracao { get; private set; }
    public int AnoLancamento { get; private set; }
    public Rating Rating { get; set; }
    public void Validacao()
    {
        var notificationHandler = new NotificationValidationHandler();
        var validator = new VideoValidator(this, notificationHandler);
        validator.Validate();
        if (notificationHandler.HasErros())
            throw new ExcecaoDeDominio("Erros de validação", notificationHandler.Erros);

    }

}
