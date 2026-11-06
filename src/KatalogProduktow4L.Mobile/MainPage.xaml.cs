using KatalogProduktow4L.Core;
using System.Collections.ObjectModel;

namespace KatalogProduktow4L.Mobile
{
    public partial class MainPage : ContentPage
    {
        private readonly List<Produkt> bazaProduktow;
        public ObservableCollection<Produkt> Produkty { get; set; }

        public MainPage()
        {
            bazaProduktow = new List<Produkt>
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
                new usługa
                {
                    Nazwa = "Montaż podzespołu",
                    Cena = 80.0,
                    Kategoria = "Usługi",
                    Ilosc = 1,
                    Producent = "Serwis Katalog"
                }
            };
            Produkty = new ObservableCollection<Produkt>();
            InitializeComponent();
            BindingContext = this;
            OdswiezListe();
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            OdswiezListe();
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
            bazaProduktow.Add(nowyProdukt);
            OdswiezListe();
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
                bazaProduktow.Remove(wybranyProdukt);
                OdswiezListe();
            }
        }

        private void OdswiezListe()
        {
            var wyniki = Produkt.Szukaj(bazaProduktow, searchEntry.Text?.Trim() ?? string.Empty);

            Produkty.Clear();
            foreach (var produkt in wyniki)
            {
                Produkty.Add(produkt);
            }
        }
        private async void Szczegoly_Clicked(object sender, EventArgs e)
        {
            if (productsCollectionView.SelectedItem is Produkt wybrany)
            {
                // połóż nową stronę na stos i przekaż jej zaznaczony produkt
                await Navigation.PushAsync(new SzczegolyPage(wybrany));
            }
            else
            {
                await DisplayAlertAsync("Brak wyboru", "Najpierw zaznacz produkt na liście.", "OK");
            }
        }

        // PushAsync przekazuje produkt bezpośrednio do konstruktora strony.
        // Shell tworzy stronę na podstawie trasy, a produkt przekazuje w słowniku.
        // Przy większej aplikacji wybrałbym Shell, bo centralizuje trasy i upraszcza
        // nawigowanie między wieloma stronami.
        private async void SzczegolyShell_Clicked(object sender, EventArgs e)
        {
            if (productsCollectionView.SelectedItem is Produkt wybrany)
            {
                await Shell.Current.GoToAsync(nameof(SzczegolyPage), new Dictionary<string, object>
                {
                    ["Produkt"] = wybrany
                });
            }
            else
            {
                await DisplayAlertAsync("Brak wyboru", "Najpierw zaznacz produkt na liście.", "OK");
            }
        }

    }
}
