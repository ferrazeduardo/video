using System;

namespace Catalogo.Domain.Entity;

public class VideoCategoria
{
    public VideoCategoria(int iD_VIDEO, int iD_CATEGORIA)
    {
        ID_VIDEO = iD_VIDEO;
        ID_CATEGORIA = iD_CATEGORIA;
    }

    public int ID_VIDEO { get; set; }
    public int ID_CATEGORIA { get; set; }
}
