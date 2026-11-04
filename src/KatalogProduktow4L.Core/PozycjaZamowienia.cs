using System;
using System.Collections.Generic;
using System.Text;

namespace KatalogProduktow4L.Core
{
    public class PozycjaZamowienia
    {



        public Produkt Produkt { get; set; }
        public int Ilosc { get; private set; }

        public PozycjaZamowienia(Produkt produkt, int ilosc)
        {



            Produkt = produkt;
            Ilosc = ilosc;
        
        
        
        }
        public double Wartosc => Produkt.Cena * Ilosc;


        public void DodajIlosc(int ilosc) => Ilosc += ilosc;
    }
}