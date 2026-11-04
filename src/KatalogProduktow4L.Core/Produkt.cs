using System;
using System.Collections.Generic;
using System.Text;

namespace KatalogProduktow4L.Core
{
    public class Produkt
    {
        public string Nazwa { get; set; }
        public double Cena { get; set; }
        public string Kategoria { get; set; }
        public int Ilosc { get; set; }
        public double WartoscMagazynu
        {
            get { return Cena * Ilosc ; }
        }
        //funkcja sprawdza czy poprawnie obliczamy wartośc magazynu
        public static void SprawdzWartosc(Produkt p)
        {

            if(p.WartoscMagazynu == p.Cena * p.Ilosc)
            {
                Console.WriteLine("Wartość magazynu jest poprawna.");
            }
            else
            {
                Console.WriteLine("Wartość magazynu jest niepoprawna.");
            }
        }
        //funkcja sprawdza czy cena produktu jest poprawna (nieujemna)
        public static void SprawdzCeny(List<Produkt> produkty)
        {
            foreach (var produkt in produkty)
            {
                if (produkt.Cena < 0)
                {
                    Console.WriteLine($"Produkt {produkt.Nazwa} ma niepoprawną cenę: {produkt.Cena}");
                }
            }
        }
        //tu nadpisujemy defaultowa funkcje tostring dla wszystkich obiektow w c#
        public override string ToString()
        {
            return $"Nazwa: {Nazwa}, Cena: {Cena}, Kategoria: {Kategoria}, Ilość: {Ilosc}, Wartość magazynu: {WartoscMagazynu}";
        }
        //dummy funkcja opi stylko zeby pokazac virtual - dopuszczam że ta funkcja zostanie nadpisana w klasach dziedziczących po klasie Produkt
        public virtual string Opis()
        {
            return "Tu jest opis produktu";
        }
    }
}