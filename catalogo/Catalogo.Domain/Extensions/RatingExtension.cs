using System;
using Catalogo.Domain.Enum;

namespace Catalogo.Domain.Extensions;

public static class RatingExtension
{
    public static Rating ToRating(this string rating)
    {
        return rating switch
        {
            "ER" => Rating.ER,
            "L" => Rating.L,
            "10" => Rating.Rate10,
            "12" => Rating.Rate12,
            "14" => Rating.Rate14,
            "16" => Rating.Rate16,
            "18" => Rating.Rate18,
            _ => throw new ArgumentException("Valor de rating inválido.")
        };
    }

    public static string ToString(this Rating rating)
    {
        return rating switch
        {
            Rating.ER => "ER",
            Rating.L =>  "L",
            Rating.Rate10 => "10",
            Rating.Rate12 => "12",
            Rating.Rate14 => "14",
            Rating.Rate16 => "16",
            Rating.Rate18 => "18",
            _ => throw new ArgumentException("Valor de rating inválido.")
        };
    }
}
