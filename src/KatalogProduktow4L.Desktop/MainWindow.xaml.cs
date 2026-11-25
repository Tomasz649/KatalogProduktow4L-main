
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using KatalogProduktow4L.Core;

namespace KatalogProduktow4L.Desktop
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var produkty = new List<Produkt>
            {
                new Podzespol
                {
                    Nazwa = "Procesor Intel Core i9",
                    Producent = "Intel",
                    Cena = 1500,
                    Kategoria = "Podzespoły",
                    Ilosc = 10
                },

                new Accessory
                {
                    Nazwa = "Myszka Logitech",
                    Cena = 100,
                    Kategoria = "Akcesoria",
                    Ilosc = 50,
                    Kolor = "Czarny"
                },

                new Usluga
                {
                    Nazwa = "Instalacja systemu Windows",
                    Cena = 200,
                    Kategoria = "Usługi",
                    Ilosc = 1,
                    Producent = "Serwis"
                }
            };

            ProductsListBox.ItemsSource = produkty;
        }

        private void ProductsListBox_SelectionChanged(
            object sender, SelectionChangedEventArgs e)
        {
            if (ProductsListBox.SelectedItem is Produkt produkt)
            {
                DetailsTextBlock.Text = produkt.Opis();
            }
            else
            {
                DetailsTextBlock.Text = "";
            }
        }
    }
}
