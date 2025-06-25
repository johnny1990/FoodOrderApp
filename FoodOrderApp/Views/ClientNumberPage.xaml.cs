using FoodOrderApp.Models;
using FoodOrderApp.ViewModels;

namespace FoodOrderApp.Views;

[QueryProperty(nameof(SelectedTable), "SelectedTable")]
public partial class ClientNumberPage : ContentPage
{
    public ClientNumberPage(ClientNumberViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    public Table SelectedTable
    {
        get => (BindingContext as ClientNumberViewModel)?.SelectedTable!;
        set => (BindingContext as ClientNumberViewModel)!.SelectedTable = value;
    }
}
