using System;
using System.Collections.Generic;
using System.Text;

namespace KatalogProduktow4L.Core
{
    public class usługa : Produkt
    {
        public string Producent { get; set; }

        public override double WartoscMagazynu => 0; // Usługi nie mają wartości magazynu

        public override string Opis()
        {
            return $"Usługa: {Nazwa}, Producent: {Producent}, Cena: {Cena}, Kategoria: {Kategoria}, Ilość: {Ilosc}";
        }


    }
}
