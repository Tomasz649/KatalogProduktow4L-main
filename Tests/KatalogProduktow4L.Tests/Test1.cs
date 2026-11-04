using KatalogProduktow4L.Core;

namespace KatalogProduktow4L.Tests
{
    [TestClass]
    public sealed class Test1
    {
        List<Produkt> PrzygotujListeProduktów()
        {
            Random r = new Random();
            var produkty = new List<Produkt>();
            for (int i = 0; i < 10000; i++)
            {
                Produkt p = new Produkt
                {
                    Nazwa = $"Produkt{i}",
                    Cena = r.NextDouble() * 100,
                    Kategoria = $"Kategoria{r.Next(1, 5)}",
                    Ilosc = r.Next(1, 20)
                };
                produkty.Add(p);
            }
            return produkty;
        }
        Produkt PrzygotujProdukt()
        {
            Random r = new Random();
            Produkt p = new Produkt
            {
                Nazwa = $"ProduktTestowy",
                Cena = r.NextDouble() * 100,
                Kategoria = $"Kategoria{r.Next(1, 5)}",
                Ilosc = r.Next(1, 20)
            };
            return p;
        }
        [TestMethod]
        public void Produkt_SprawdzWartoscMagazynu()
        {
            // Arrange
            var produkt = PrzygotujProdukt();
            double sprawdzonaWartosc = produkt.Cena * produkt.Ilosc;
            // Act
            double wartoscMagazynu = produkt.WartoscMagazynu;
            // Assert
            Assert.AreEqual(sprawdzonaWartosc, wartoscMagazynu, "Wartość magazynu powinna być równa Cena * Ilosc.");
        }
        [TestMethod]
        public void Produkt_CenaUjemna()
        {
            // Arrange
            var produkt = PrzygotujProdukt();
            // Ustawiamy cenę na wartość ujemną
            produkt.Cena *= -1;
            // Act
            bool isCenaDodatnia = produkt.Cena >= 0;
            // Assert
            Assert.IsFalse(isCenaDodatnia, "Cena produktu powinna być nieujemna.");
        }
        [TestMethod]
        public void PoliczWszystkieProdukty()
        {
            // Arrange
            var produkty = PrzygotujListeProduktów();
            // Act
            int liczbaProduktow = produkty.Count;
            // Assert
            Assert.AreEqual(10000, liczbaProduktow, "Liczba produktów powinna wynosić 10000.");
        }
        [TestMethod]
        public void SprawdzCeny()
        {
            // Arrange
            var produkty = PrzygotujListeProduktów();
            // Act
            int licznik = 0;
            foreach (var produkt in produkty)
            {
                if (produkt.Cena > 0)
                {
                    licznik++; // za każdy produkt z ceną większą od 0 zwiększamy licznik
                }
            }
            // Assert czy ilość produktów z ceną jest większą od zera równa całkowitej liczbie produktów
            Assert.AreEqual(produkty.Count, licznik, "Wszystkie produkty powinny mieć cenę większą od 0.");
        }
        //Robimy dwa dodatkowe testy:
        //1. Sprawdzamy czy są dokładnie 3 kategorie produktów w liście
        //2. Sprawdzamy czy w kategorii "Kategoria1" jest dokładnie 5 produktów
        //Najpierw napiszcie sobie funkcję pomocniczą która przygotuje wam dane do testów
    




    [TestMethod]


        public void SzukajProduktowWKategoriach()
        {

            // Arrange
            var produkty = PrzygotujListeProduktów();
            string szukanaNazwa = "Produkt1"; // szukamy produktów zawierających "Produkt1" w nazwie
                                              // Act
            var znalezioneProdukty = Produkt.Szukaj(produkty, szukanaNazwa);
            // Assert
            foreach (var produkt in znalezioneProdukty)
            {
                StringAssert.Contains(produkt.Nazwa, szukanaNazwa, $"Znaleziony produkt {produkt.Nazwa} powinien zawierać '{szukanaNazwa}' w nazwie.");
            }
        }



        [TestMethod]
        public void SzukajProduktowPoNazwie_ZwracaPoprawnaLiczbeWynikow()
        {
            var produkty = PrzygotujListeProduktów();

            var znalezioneProdukty = Produkt.Szukaj(produkty, "000");

            Assert.AreEqual(9, znalezioneProdukty.Count);
        }



        private List<Produkt> PrzygotujListeZKategoriami()
        {
            return new List<Produkt>
            {
                new Produkt { Nazwa = "Produkt1", Kategoria = "Kategoria1", Cena = 10, Ilosc = 1 },
                new Produkt { Nazwa = "Produkt2", Kategoria = "Kategoria1", Cena = 20, Ilosc = 1 },
                new Produkt { Nazwa = "Produkt3", Kategoria = "Kategoria1", Cena = 30, Ilosc = 1 },
                new Produkt { Nazwa = "Produkt4", Kategoria = "Kategoria1", Cena = 40, Ilosc = 1 },
                new Produkt { Nazwa = "Produkt5", Kategoria = "Kategoria1", Cena = 50, Ilosc = 1 },
                new Produkt { Nazwa = "Produkt6", Kategoria = "Kategoria2", Cena = 60, Ilosc = 1 },
                new Produkt { Nazwa = "Produkt7", Kategoria = "Kategoria2", Cena = 70, Ilosc = 1 },
                new Produkt { Nazwa = "Produkt8", Kategoria = "Kategoria3", Cena = 80, Ilosc = 1 }
            };
        }



        [TestMethod]
        public void Produkty_MajaDokladnieTrzyKategorie()
        {
            var produkty = PrzygotujListeZKategoriami();

            var liczbaKategorii = produkty
                .Select(p => p.Kategoria)
                .Distinct()
                .Count();

            Assert.AreEqual(3, liczbaKategorii);
        }



        [TestMethod]
        public void Kategoria1_MaPieciuProduktow()
        {
            var produkty = PrzygotujListeZKategoriami();

            var liczbaProduktow = produkty.Count(p => p.Kategoria == "Kategoria1");

            Assert.AreEqual(5, liczbaProduktow);
        }

        [TestMethod]
        public void PusteZamowienie_MaWartoscZero()
        {
            var zamowienie = new Zamowienie();

            Assert.AreEqual(0, zamowienie.WartoscZamowienia);
        }




        [TestMethod]
        public void DodanieTegoSamegoProduktu_ZwiekszaIloscJednejPozycji()
        {
            var zamowienie = new Zamowienie();
            var produkt = new Produkt { Nazwa = "Produkt", Cena = 10 };

            zamowienie.Dodaj(produkt, 2);
            zamowienie.Dodaj(produkt, 3);

            Assert.AreEqual(1, zamowienie.Pozycje.Count);
            Assert.AreEqual(5, zamowienie.Pozycje[0].Ilosc);
            Assert.AreEqual(50, zamowienie.WartoscZamowienia);
        }

        [TestMethod]
        public void DodanieProduktuZIlosciaZeroLubUjemna_RzucaWyjatek()
        {
            var zamowienie = new Zamowienie();
            var produkt = PrzygotujProdukt();

            var wyjatek = Assert.ThrowsExactly<ArgumentException>(
                () => zamowienie.Dodaj(produkt, 0));

            StringAssert.Contains(wyjatek.Message, "Ilość musi być większa od zera.");
        }

        [TestMethod]
        public void Zamowienie_LiczyWartoscPodzespoluIUslugi()
        {
            var zamowienie = new Zamowienie();
            var podzespol = new Podzespol { Nazwa = "Podzespół", Cena = 25 };
            var usluga = new usługa { Nazwa = "Usługa", Cena = 100 };

            zamowienie.Dodaj(podzespol, 2);
            zamowienie.Dodaj(usluga, 1);

            Assert.AreEqual(150, zamowienie.WartoscZamowienia);
        }

        [TestMethod]
        public void Usluga_MaWartoscMagazynuRownaZero()
        {
            var usluga = new usługa { Nazwa = "Usługa", Cena = 20, Ilosc = 5 };

            Assert.AreEqual(0, usluga.WartoscMagazynu);
        }

        [TestMethod]
        public void OpisAkcesorium_ZawieraKolor()
        {
            var akcesorium = new Accessory
            {
                Nazwa = "Akcesorium1",
                Cena = 15,
                Kategoria = "Kategoria2",
                Ilosc = 3,
                color = "Czerwony"
            };

            StringAssert.Contains(akcesorium.Opis(), "Czerwony");
        }


    }
}
