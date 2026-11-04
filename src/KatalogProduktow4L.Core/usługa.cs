using System;
using System.Collections.Generic;
using System.Text;

namespace KatalogProduktow4L.Core
{
    public class usługa : Produkt
    {
        public override double WartoscMagazynu => 0; // Usługi nie mają wartości magazynu

        public override string Opis()
        {
            return $"Usługa: {Nazwa}, Cena: {Cena}, Kategoria: {Kategoria}, Ilość: {Ilosc}";
        }


    }
}
