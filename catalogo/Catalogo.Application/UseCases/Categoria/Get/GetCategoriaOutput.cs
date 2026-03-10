using System;
namespace Catalogo.Application.UseCases.Categoria.Get;

public class GetCategoriaOutput<T>
{
    public T Categoria { get; set; }
}
