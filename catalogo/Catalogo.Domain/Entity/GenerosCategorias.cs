using System;
using domain = Catalogo.Domain.Entity;
namespace Catalogo.Domain.Entity;

public class GenerosCategorias
{
  

    public GenerosCategorias(int generoId, int categoriaId)
    {
        this.ID_GENERO = generoId;
        this.ID_CATEGORIA = categoriaId;
    }

    public int ID_CATEGORIA{ get; set; }
    public domain.Categoria Categoria { get; set; }
    public int ID_GENERO { get; set; }
    public Genero Genero { get; set; }
}
