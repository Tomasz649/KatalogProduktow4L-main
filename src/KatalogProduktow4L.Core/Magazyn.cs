using System;
using System.Collections.Generic;
using System.Text;

namespace KatalogProduktow4L.Core
{
    public class Magazyn
    {

        public static double ObliczWartoscMagazynu(List<Produkt> produkty)
        {
            return produkty.Sum(p => p.WartoscMagazynu);
        }

    }
}
