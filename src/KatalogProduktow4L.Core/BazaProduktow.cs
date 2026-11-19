
using System;
using System.Collections.Generic;
using System.Text;

namespace KatalogProduktow4L.Core
{
    public static class BazaProduktow
    {
        public static List<Produkt> DajProdukty()
        {
            return new List<Produkt>
            {
                new Produkt { Nazwa = "Produkt1", Cena = 10.0, Kategoria = "Kategoria1", Ilosc = 5 },
                new Produkt { Nazwa = "Produkt2", Cena = 20.0, Kategoria = "Kategoria2", Ilosc = 3 },
                new Produkt { Nazwa = "Produkt3", Cena = 15.0, Kategoria = "Kategoria1", Ilosc = 8 },
                new Podzespol
                {
                    Nazwa = "Dysk SSD",
                    Cena = 250.0,
                    Kategoria = "Elektronika",
                    Ilosc = 4,
                    Producent = "Kingston"
                },
                new Usluga
                {
                    Nazwa = "Montaż podzespołu",
                    Cena = 80.0,
                    Kategoria = "Usługi",
                    Ilosc = 1,
                    Producent = "Serwis Katalog"
                },
                new Accessory
                {
                    Nazwa = "Myszka Logitech",
                    Cena = 100.0,
                    Kategoria = "Akcesoria",
                    Ilosc = 50,
                    Kolor = "Czarny"
                }
            };
        }
    }
}
