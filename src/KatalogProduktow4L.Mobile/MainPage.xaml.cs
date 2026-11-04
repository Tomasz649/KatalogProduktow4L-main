using KatalogProduktow4L.Core;
using System.Collections.ObjectModel;

namespace KatalogProduktow4L.Mobile
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Produkt> Produkty { get; set; }

        public MainPage()
        {
            Produkty = new ObservableCollection<Produkt>
            {
                new Produkt { Nazwa = "Produkt1", Cena = 10.0, Kategoria = "Kategoria1", Ilosc = 5 },
                new Produkt { Nazwa = "Produkt2", Cena = 20.0, Kategoria = "Kategoria2", Ilosc = 3 },
                new Produkt { Nazwa = "Produkt3", Cena = 15.0, Kategoria = "Kategoria1", Ilosc = 8 }
            };
            InitializeComponent();
            BindingContext = this;
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
         
        }
        private void DodajProdukt_Clicked(object sender, EventArgs e)
        {
            //odczytujemy wartości z pól tekstowych
            string nazwa = nazwaEntry.Text;
            double cena = double.Parse(cenaEntry.Text);
            string kategoria = kategoriaPicker.SelectedItem.ToString();

            //tworzymy nową instancję produktu
            Produkt nowyProdukt = new Produkt
            {
                Nazwa = nazwa,
                Cena = cena,
                Kategoria = kategoria,
                Ilosc = 0 // domyślna ilość
            };
            Produkty.Add(nowyProdukt);
        }
        private void UsunProdukt_Clicked(object sender, EventArgs e)
        {
            if (productsCollectionView.SelectedItem is Produkt wybranyProdukt)
            {
                Produkty.Remove(wybranyProdukt);
            }
        }
    }
}
