     using KatalogProduktow4L.Core;

List<Produkt> produkty = new List<Produkt>
{
    new Produkt { Nazwa = "Produkt1", Cena = 10.0, Kategoria = "Kategoria1", Ilosc = 5 },
    new Produkt { Nazwa = "Produkt2", Cena = 20.0, Kategoria = "Kategoria2", Ilosc = 3 },
    new Produkt { Nazwa = "Produkt3", Cena = 15.0, Kategoria = "Kategoria1", Ilosc = 8 },
    new Produkt { Nazwa = "Produkt4", Cena = 30.0, Kategoria = "Kategoria3", Ilosc = 2 },
    new Produkt { Nazwa = "Produkt5", Cena = 25.0, Kategoria = "Kategoria2", Ilosc = 6 }
};
//tworze slownik nazwa kategorii <-> lista produktów w tej kategorii
var produktyWKategoriach = new Dictionary<string, List<Produkt>>();
//idziemy po globalnej tablicy produktów
foreach (var produkt in produkty)
{
    //sprawdzamy czy istnieje kategoria w slowniku o tej nazwie
    if (!produktyWKategoriach.ContainsKey(produkt.Kategoria))
    {
        //jesli nie istnieje to tworzymy nowa liste produktow w tej kategorii
        produktyWKategoriach[produkt.Kategoria] = new List<Produkt>();
    }
    //dodajemy produkt do listy produktow w tej kategorii
    produktyWKategoriach[produkt.Kategoria].Add(produkt);
}
//wypisz tylko produkty w kategorii "kategoria1"
Console.WriteLine("Produkty w kategorii 'kategoria1':");
foreach (var produkt in produktyWKategoriach["Kategoria1"])
{
    Console.WriteLine(produkt.Nazwa);
}
Console.WriteLine("Wszystkie produkty:");
foreach (var produkt in produkty)
{
    Console.WriteLine(produkt.ToString());
}
Console.WriteLine("Produkty o cenie mniejszej niż 20:");
foreach (var produkt in produkty.Where(produkt => produkt.Cena < 20))
{
    Console.WriteLine(produkt.Nazwa);
}
Console.WriteLine("Produkty posortowane według ceny:");
foreach (var produkt in produkty.OrderBy(produkt => produkt.Cena))
{
    Console.WriteLine(produkt.Nazwa);
}
//sprawdz wartosc na przykładzie pierwszego produktu
Produkt.SprawdzWartosc(produkty[0]);
//sprawdz ceny wszystkich produktów
Produkt.SprawdzCeny(produkty);