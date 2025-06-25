using FoodOrderApp.Models;
using FoodOrderApp.ViewModels;

namespace FoodOrderApp.Views;

[QueryProperty(nameof(SelectedTable), "SelectedTable")]
[QueryProperty(nameof(ClientCount), "ClientCount")]
public partial class ProductSelectionPage : ContentPage
{
    public ProductSelectionPage(ProductSelectionViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    public Table SelectedTable
    {
        get => (BindingContext as ProductSelectionViewModel)?.SelectedTable!;
        set => (BindingContext as ProductSelectionViewModel)!.SelectedTable = value;
    }

    public int ClientCount
    {
        get => (BindingContext as ProductSelectionViewModel)?.ClientCount ?? 1;
        set => (BindingContext as ProductSelectionViewModel)!.ClientCount = value;
    }

    private void OnClearOrderClicked(object sender, EventArgs e)
    {
        if (BindingContext is ProductSelectionViewModel viewModel)
        {
            viewModel.ClearOrder();
        }
    }

}
