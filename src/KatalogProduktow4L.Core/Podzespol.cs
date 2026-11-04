using System;
using System.Collections.Generic;
using System.Text;

namespace KatalogProduktow4L.Core
{
    /// <summary>
    /// Klasa podzespol ma dziedziczyc z klasy Produkt i reprezentuje jaks fizyczna czesc na magazynie
    /// </summary>
    public class Podzespol : Produkt //Podzespol dziedziczy po klasie Produkt
    {
        public string Producent { get; set; } //oprocz pól z klasy Produkt, Podzespol ma dodatkowe pole Producent

        //ponownie nadpisujemy funkcje tostring aby wypisywala wszystkie pola z klasy Produkt oraz pole Producent
        //w ten sposób klasa dziedzicząca ma inną implementację dla tej samej funkcji niż klasa bazowa
        public override string ToString()
        {
            return $"Nazwa: {Nazwa}, Cena: {Cena}, Kategoria: {Kategoria}, Ilość: {Ilosc}, Wartość magazynu: {WartoscMagazynu}, Producent: {Producent}";
        }
        public string Opis()
        {
            return $"Producent: {Producent}, Nazwa: {Nazwa}, Cena: {Cena}, Kategoria: {Kategoria}, Ilość: {Ilosc}, Wartość magazynu: {WartoscMagazynu}";
        }
    }
}
