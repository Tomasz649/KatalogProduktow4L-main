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
            errorLabel.IsVisible = false;

            if (string.IsNullOrWhiteSpace(nazwaEntry.Text))
            {
                PokazBlad("Wpisz nazwę produktu.");
                return;
            }

            if (!double.TryParse(cenaEntry.Text, out double cena) || cena < 0)
            {
                PokazBlad("Wpisz poprawną, nieujemną cenę.");
                return;
            }

            if (kategoriaPicker.SelectedItem is not string kategoria)
            {
                PokazBlad("Wybierz kategorię produktu.");
                return;
            }

            //tworzymy nową instancję produktu
            Produkt nowyProdukt = new Produkt
            {
                Nazwa = nazwaEntry.Text.Trim(),
                Cena = cena,
                Kategoria = kategoria,
                Ilosc = 0 // domyślna ilość
            };
            Produkty.Add(nowyProdukt);
            nazwaEntry.Text = string.Empty;
            cenaEntry.Text = string.Empty;
            kategoriaPicker.SelectedItem = null;
        }

        private void PokazBlad(string komunikat)
        {
            errorLabel.Text = komunikat;
            errorLabel.IsVisible = true;
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
