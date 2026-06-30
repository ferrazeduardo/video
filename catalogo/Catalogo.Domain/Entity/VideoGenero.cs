using System;

namespace Catalogo.Domain.Entity;

public class VideoGenero
{
    public VideoGenero(int iD_VIDEO, int iD_GENERO)
    {
        ID_VIDEO = iD_VIDEO;
        ID_GENERO = iD_GENERO;
    }

    public int ID_VIDEO { get; set; }
    public int ID_GENERO { get; set; }
}
