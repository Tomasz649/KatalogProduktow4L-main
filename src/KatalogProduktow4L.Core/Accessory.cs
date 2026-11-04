using System;
using System.Collections.Generic;
using System.Text;

namespace KatalogProduktow4L.Core
{
    public class Accessory : Produkt
    {
        public string color { get; set; }

        public override string Opis()
        {
            return $"Kolor: {color}, Nazwa: {Nazwa}, Cena: {Cena}, Kategoria: {Kategoria}, Ilość: {Ilosc}";
        }
    }
}
