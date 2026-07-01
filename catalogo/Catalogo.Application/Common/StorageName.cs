using System;

namespace Catalogo.Application.Common;

public static class StorageName
{
    public static string Create(int id, string propertyName, string extension)
    {
        return $"{id}-{propertyName}.{extension}";
    }
}
