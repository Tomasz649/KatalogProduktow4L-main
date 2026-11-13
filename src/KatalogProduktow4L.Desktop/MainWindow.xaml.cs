using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KatalogProduktow4L.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var produkty = new List<Produkt>
            {
                new Podzespol {Nazwa = "Procesor Intel Core i9", Producent= "Intel" , Cena = 1500, Kategoria = "Podzespoły", Ilosc = 10},
                new Akcesorium {Nazwa = "Myszka Logitech", Cena = 100, Kategoria = "Akcesoria", Ilosc = 50, Kolor="Czarny"},
                new Usluga {Nazwa = "Instalacja systemu Windows", Cena = 200, Kategoria = "Usługi"}
            };
            ProduktyListBox.ItemsSource = produkty;
        }
    }
}