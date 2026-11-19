using System;
using System.Collections.Generic;

namespace KatalogProduktow4L.Core
{
    public class Produkt : IWyceniany
    {
        public string Nazwa { get; set; }
        public double Cena { get; set; }
        public string Kategoria { get; set; }
        public int Ilosc { get; set; }

        public virtual double WartoscMagazynu
        {
            get { return Cena * Ilosc; }
        }

        public static void SprawdzWartosc(Produkt p)
        {
            if (p.WartoscMagazynu == p.Cena * p.Ilosc)
            {
                Console.WriteLine("Wartość magazynu jest poprawna.");
            }
            else
            {
                Console.WriteLine("Wartość magazynu jest niepoprawna.");
            }
        }

        public static void SprawdzCeny(List<Produkt> produkty)
        {
            foreach (var produkt in produkty)
            {
                if (produkt.Cena < 0)
                {
                    Console.WriteLine(
                        $"Produkt {produkt.Nazwa} ma niepoprawną cenę: {produkt.Cena}");
                }
            }
        }

        public static List<Produkt> Szukaj(
            List<Produkt> produkty, string szukanaNazwa)
        {
            if (produkty == null)
                throw new ArgumentNullException(nameof(produkty));

            if (szukanaNazwa == null)
                throw new ArgumentNullException(nameof(szukanaNazwa));

            var znalezioneProdukty = new List<Produkt>();

            foreach (var produkt in produkty)
            {
                if (produkt?.Nazwa != null &&
                    produkt.Nazwa.Contains(
                        szukanaNazwa,
                        StringComparison.OrdinalIgnoreCase))
                {
                    znalezioneProdukty.Add(produkt);
                }
            }

            return znalezioneProdukty;
        }

        public virtual string Opis()
        {
            return $"Nazwa: {Nazwa}, Cena: {Cena} zł, " +
                   $"Kategoria: {Kategoria}, Ilość: {Ilosc}, " +
                   $"Wartość magazynu: {WartoscMagazynu} zł";
        }

        public override string ToString()
        {
            return Opis();
        }
    }
}