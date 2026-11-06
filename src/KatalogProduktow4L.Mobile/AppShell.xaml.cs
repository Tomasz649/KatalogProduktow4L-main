namespace KatalogProduktow4L.Mobile
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(SzczegolyPage), typeof(SzczegolyPage));
        }
    }
}
