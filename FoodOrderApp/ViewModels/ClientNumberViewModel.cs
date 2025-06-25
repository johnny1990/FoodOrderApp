using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FoodOrderApp.Models;
using System.Windows.Input;

namespace FoodOrderApp.ViewModels;

public partial class ClientNumberViewModel : ObservableObject
{
    [ObservableProperty]
    int clientCount = 1;

    [ObservableProperty]
    Table selectedTable;

    public ClientNumberViewModel() { }

    [RelayCommand]
    async Task Continue()
    {
        if (SelectedTable == null)
            return;

        await Shell.Current.GoToAsync(nameof(Views.ProductSelectionPage), true, new Dictionary<string, object>
        {
            { "SelectedTable", SelectedTable },
            { "ClientCount", ClientCount }
        });
    }
}
