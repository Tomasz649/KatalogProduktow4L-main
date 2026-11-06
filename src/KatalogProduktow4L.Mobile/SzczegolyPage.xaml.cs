using KatalogProduktow4L.Core;

namespace KatalogProduktow4L.Mobile;

public partial class SzczegolyPage : ContentPage, IQueryAttributable
{
    private bool otwartaPrzezShell;

    public SzczegolyPage(Produkt produkt)
    {
        InitializeComponent();
        UstawProdukt(produkt);
    }

    public SzczegolyPage()
    {
        InitializeComponent();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        otwartaPrzezShell = true;

        if (query.TryGetValue("Produkt", out var wartosc) && wartosc is Produkt produkt)
        {
            UstawProdukt(produkt);
        }
    }

    private void UstawProdukt(Produkt produkt)
    {
        BindingContext = produkt;
        opisLabel.Text = produkt.Opis();
    }

    private async void Wroc_Clicked(object sender, EventArgs e)
    {
        if (otwartaPrzezShell)
        {
            await Shell.Current.GoToAsync("..");
        }
        else
        {
            await Navigation.PopAsync();
        }
    }
}
