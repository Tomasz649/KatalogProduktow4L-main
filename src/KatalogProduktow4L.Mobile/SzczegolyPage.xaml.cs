using KatalogProduktow4L.Core;

namespace KatalogProduktow4L.Mobile;

public partial class SzczegolyPage : ContentPage, IQueryAttributable
{
    private bool otwartaPrzezShell;
    private Action<Produkt> onDelete;
    private Action<Produkt> onUpdate;
    private Produkt aktualnyProdukt;

    public SzczegolyPage(Produkt produkt, Action<Produkt> onDelete = null, Action<Produkt> onUpdate = null)
    {
        InitializeComponent();
        this.onDelete = onDelete;
        this.onUpdate = onUpdate;
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
        aktualnyProdukt = produkt;
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

    private async void Zapisz_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(nazwaEntry.Text))
            {
                await DisplayAlert("B³¹d", "Nazwa nie mo¿e byæ pusta", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(kategoriaEntry.Text))
            {
                await DisplayAlert("B³¹d", "Kategoria nie mo¿e byæ pusta", "OK");
                return;
            }

            if (!decimal.TryParse(cenaEntry.Text, out decimal cena) || cena <= 0)
            {
                await DisplayAlert("B³¹d", "Cena musi byæ liczb¹ wiêksz¹ ni¿ 0", "OK");
                return;
            }

            aktualnyProdukt.Nazwa = nazwaEntry.Text;
            aktualnyProdukt.Kategoria = kategoriaEntry.Text;
            aktualnyProdukt.Cena = (double)cena;

            onUpdate?.Invoke(aktualnyProdukt);
            BindingContext = aktualnyProdukt;
            opisLabel.Text = aktualnyProdukt.Opis();

            await DisplayAlert("Sukces", "Produkt zosta³ zaktualizowany", "OK");
        }
        catch
        {
            await DisplayAlert("B³¹d", "Nie uda³o siê zapisaæ zmian", "OK");
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
