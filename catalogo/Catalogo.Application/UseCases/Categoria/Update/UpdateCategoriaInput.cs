using System;
using MediatR;

namespace Catalogo.Application.UseCases.Categoria.Update;

public class UpdateCategoriaInput : IRequest<UpdateCategoriaOutput>
{
    public Guid id { get; set; }
    public string nome { get; set; }
    public string descricao { get; set; }
    public string status { get; set; }
}
