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
            foreach(var produkt in produkty)
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
    }
}
