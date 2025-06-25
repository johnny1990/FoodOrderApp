using FoodOrderApp.Models;
using FoodOrderApp.ViewModels;

namespace FoodOrderApp.Views;

public partial class TableSelectionPage : ContentPage
{
    public TableSelectionPage(TableSelectionViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}