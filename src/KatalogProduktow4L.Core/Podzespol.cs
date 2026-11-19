
namespace KatalogProduktow4L.Core
{
    public class Podzespol : Produkt
    {
        public string Producent { get; set; }

        public override string Opis()
        {
            return $"Podzespół: {Nazwa}, Producent: {Producent}, " +
                   $"Cena: {Cena} zł, Kategoria: {Kategoria}, " +
                   $"Ilość: {Ilosc}, Wartość magazynu: {WartoscMagazynu} zł";
        }
    }
}
