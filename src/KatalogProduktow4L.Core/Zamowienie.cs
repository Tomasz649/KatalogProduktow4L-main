using System;
using System.Collections.Generic;
using System.Text;

namespace KatalogProduktow4L.Core
{
    public class Zamowienie
    {




        private readonly List<PozycjaZamowienia> pozycje = new List<PozycjaZamowienia>();
        public IReadOnlyList<PozycjaZamowienia> Pozycje => pozycje;

        public void Dodaj(Produkt produkt, int ilosc)
        {
            if (ilosc <= 0)
                throw new ArgumentException("Ilość musi być większa od zera.");
            var istniejacaPozycja = pozycje.FirstOrDefault(p => p.Produkt == produkt);
            if (istniejacaPozycja != null)
                istniejacaPozycja.DodajIlosc(ilosc);
            else
                pozycje.Add(new PozycjaZamowienia(produkt, ilosc));
        }
        public double WartoscZamowienia => pozycje.Sum(p => p.Wartosc);
    }
}