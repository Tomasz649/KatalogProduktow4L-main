using KatalogProduktow4L.Core;

namespace KatalogProduktow4L.Mobile;

public partial class SzczegolyPage : ContentPage, IQueryAttributable
{
    private bool otwartaPrzezShell;
    private Action<Produkt> onDelete;

    public SzczegolyPage(Produkt produkt, Action<Produkt> onDelete = null)
    {
        InitializeComponent();
        this.onDelete = onDelete;
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


    private async void UsunProdukt_Clicked(object sender, EventArgs e)
    {
        bool confirmed = await DisplayAlert("Potwierdzenie", "Na pewno chcesz usun¹æ ten produkt?", "Tak", "Nie");

        if (confirmed && BindingContext is Produkt produkt)
        {
            onDelete?.Invoke(produkt);
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
}
