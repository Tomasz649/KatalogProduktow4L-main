using System;
using System.Collections.Generic;
using System.Text;

namespace KatalogProduktow4L.Core
{
    public class Zestaw : IWyceniany
    {
        private readonly List<Produkt> skladniki;



        public string Nazwa { get; set; }
        public Zestaw(string nazwa, List<Produkt> produkty)
        {
            Nazwa = nazwa;
            skladniki = produkty ?? new List<Produkt>();
        }



        public double Cena => skladniki.Sum(p => p.Cena);

        double IWyceniany.Cena { get => Cena; set => throw new NotImplementedException(); }
    }
}