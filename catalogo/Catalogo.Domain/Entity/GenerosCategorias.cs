using System;
using domain = Catalogo.Domain.Entity;
namespace Catalogo.Domain.Entity;

public class GenerosCategorias
{
  

    public GenerosCategorias(int iD_GENERO, int iD_CATEGORIA)
    {
        this.ID_GENERO = iD_GENERO;
        this.ID_CATEGORIA = iD_CATEGORIA;
    }

    public int ID_CATEGORIA{ get; set; }
    public domain.Categoria Categoria { get; set; }
    public int ID_GENERO { get; set; }
    public Genero Genero { get; set; }
}
