using System;

namespace Catalogo.Domain.Entity;

public class VideoCastFilme
{
    public VideoCastFilme(int iD_VIDEO, int iD_CAST_FILME)
    {
        ID_VIDEO = iD_VIDEO;
        ID_CAST_FILME = iD_CAST_FILME;
    }

    public int ID_VIDEO { get; set; }
    public int ID_CAST_FILME { get; set; }
}
