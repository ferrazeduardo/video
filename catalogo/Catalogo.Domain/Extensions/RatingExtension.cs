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
        };
    }
}
