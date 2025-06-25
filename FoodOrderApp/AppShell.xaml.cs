using FoodOrderApp.Views;

namespace FoodOrderApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(TableSelectionPage), typeof(TableSelectionPage));
            Routing.RegisterRoute(nameof(ClientNumberPage), typeof(ClientNumberPage));
            Routing.RegisterRoute(nameof(ProductSelectionPage), typeof(ProductSelectionPage));
        }
    }
}
