using KatalogProduktow4L.Core;
using Xamarin.KotlinX.Coroutines.Channels;

namespace KatalogProduktow4L.Mobile;

public partial class SzczegolyPage : ContentPage
{
    // strona dostaje produkt z zewnątrz - to jest "przekazanie danych"
    public SzczegolyPage(Produkt produkt)
    {
        InitializeComponent();
        BindingContext = produkt;          // etykiety z {Binding ...} czytają z tego obiektu
        opisLabel.Text = produkt.Opis();   // Opis() wywołany na konkretnym obiekcie
    }

    private async void Wroc_Clicked(object sender, EventArgs e)
    {
        // zdejmij tę stronę ze stosu - wracamy do poprzedniej
        await Navigation.PopAsync();
    }
}