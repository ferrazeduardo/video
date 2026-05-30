using System;
using System.ComponentModel.DataAnnotations;
using Catalogo.Domain.Entity;
using Catalogo.Domain.Validation;

namespace Catalogo.Domain.Validatiors;

public class VideoValidator : Validation.Validator
{
    private readonly Video _video;
    public VideoValidator(Video video,ValidationHandler handler) : base(handler)
    {
        _video = video;
    }

    public override void Validate()
    {
        if(string.IsNullOrEmpty(_video.Descricao))
        _handler.HandleError("Descrição é obrigatorio.");

        if(_video.Descricao.Length > 40000)
            _handler.HandleError("Descrição não pode ter mais de 4000 caracteres.");

        if(string.IsNullOrEmpty(_video.Titulo))
            _handler.HandleError("Titulo é obrigatório.");

        if(_video.Titulo.Length > 255)
            _handler.HandleError("Titulo tem que ter menos de 255 caracteres.");
    }
}
