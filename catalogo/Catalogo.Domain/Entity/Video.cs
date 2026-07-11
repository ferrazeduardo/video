using System;
using Catalogo.Domain.Enum;
using Catalogo.Domain.Exceptions;
using Catalogo.Domain.SeedWork;
using Catalogo.Domain.Validation;
using Catalogo.Domain.Validatiors;
using Catalogo.Domain.ValueObject;

namespace Catalogo.Domain.Entity;

public class Video : AggregationRoot
{
    public Video(string titulo, string descricao, bool publicado, int duracao, int anoLancamento, Rating rating)
    {
        Titulo = titulo;
        Descricao = descricao;
        AnoLancamento = anoLancamento;
        Duracao = duracao;
        Publicado = publicado;
        DataCriacao = DateTime.Now;
        Rating = rating;
        Validacao();
    }

    public string Titulo { get; private set; }
    public string Descricao { get; private set; }
    public bool Publicado { get; private set; }
    public DateTime DataCriacao { get; private set; }
    public int Duracao { get; private set; }
    public int AnoLancamento { get; private set; }
    public Rating Rating { get; private set; }
    public Image? Thumb { get; private set; }
    public Image? ThumbHalf { get; private set; }
    public Image? banner { get; private set; }
    public Media? Media { get; private set; }
    public Media? Trailer { get; private set; }
    public ICollection<Guid> Categorias { get; private set; } = [];
    public ICollection<Guid> Generos { get; private set; } = [];
    public ICollection<Guid> CastsFilme { get; private set; } = [];
    public void Validacao()
    {
        var notificationHandler = new NotificationValidationHandler();
        var validator = new VideoValidator(this, notificationHandler);
        validator.Validate();
        if (notificationHandler.HasErros())
            throw new ExcecaoDeDominio("Erros de validação", notificationHandler.Erros);

    }

    public void UpdateMedia(string caminhoArquivo)
    {
        Media = new Media(caminhoArquivo);
    }

    public void UpdateTrailer(string caminhoArquivo)
    {
        Trailer = new Media(caminhoArquivo);
    }
    public void UpdateThumb(string caminho)
    {
        Thumb = new Image(caminho);
    }

    public void UpdateThumbHald(string caminho)
    {
        ThumbHalf = new Image(caminho);
    }

    public void UpdateBanner(string caminho)
    {
        banner = new Image(caminho);
    }

    public void UpdateProcessando()
    {
        if (Media is null)
            throw new NullReferenceException("Media não encontrada");

        Media.UpdateProcessando();
    }

    public void UpdateProcessado(string caminhoArquivo)
    {
        if (Media is null)
            throw new NullReferenceException("Media não encontrada");

        Media.UpdateProcessado(caminhoArquivo);
    }

    public void AddCategoria(Guid categoriaId)
    {
        Categorias.Add(categoriaId);
    }

    public void RemoveCategoria(Guid idCategoria)
    {
        Categorias = Categorias.Where(c => c != idCategoria).ToList();
    }

    public void AddGenero( Guid generoId)
    {
        Generos.Add(generoId);
    }

    public void RemoveGenero(Guid idGenero)
    {
        Generos = Generos.Where(g => g != idGenero).ToList();
    }

    public void AddCast(Guid castId)
    {
        CastsFilme.Add(castId);
    }

    public void RemoveCast(Guid idCast)
    {
        CastsFilme = CastsFilme.Where(c => c != idCast).ToList();
    }

    public void Update(string titulo, string descricao, int anoLancamento, int duracao, bool publicado, Rating rating)
    {
        Titulo = titulo ?? Titulo;
        Descricao = descricao ?? Descricao;  
        AnoLancamento = anoLancamento != 0 ? anoLancamento : AnoLancamento;
        Duracao = duracao != 0 ? duracao : Duracao;
        Publicado = publicado != Publicado ? publicado : Publicado;
        Rating = rating != Rating ? rating : Rating;
        Validacao();
    }
}
