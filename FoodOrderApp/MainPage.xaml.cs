using FoodOrderApp.ViewModels;
using FoodOrderApp.Views;

namespace FoodOrderApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }

        private async void OnTableSelectionClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(TableSelectionPage));
        }

        private async void OnClientNumberClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(ClientNumberPage));
        }

        private async void OnProductSelectionClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(ProductSelectionPage));
        }
    }

}
