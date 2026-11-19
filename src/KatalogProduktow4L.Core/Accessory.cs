using System;

namespace KatalogProduktow4L.Core
{
    public class Accessory : Produkt
    {
        public string Kolor { get; set; }

        public override string Opis()
        {
            return $"Kolor: {Kolor}, Nazwa: {Nazwa}, Cena: {Cena}, Kategoria: {Kategoria}, Ilość: {Ilosc}";
        }
    }
}