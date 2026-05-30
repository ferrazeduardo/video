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
        throw new NotImplementedException();
    }
}
