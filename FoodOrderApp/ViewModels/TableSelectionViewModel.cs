
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Input;
    using FoodOrderApp.Models;
    using FoodOrderApp.Data;
    using System.Collections.ObjectModel;
    using Microsoft.Maui.Controls;

    namespace FoodOrderApp.ViewModels;

public partial class TableSelectionViewModel : ObservableObject
{
    private readonly OrderAppDbContext _dbContext;

    [ObservableProperty]
    ObservableCollection<Table> tables = new();

    public TableSelectionViewModel(OrderAppDbContext dbContext)
    {
        _dbContext = dbContext;
        LoadTables();
    }

    private void LoadTables()
    {
        if (!_dbContext.Tables.Any())
        {
            _dbContext.Tables.AddRange(
                new Table { Name = "Table 1" },
                new Table { Name = "Table 2" },
                new Table { Name = "Table 3" }
            );
            _dbContext.SaveChanges();
        }

        Tables = new ObservableCollection<Table>(_dbContext.Tables.ToList());
    }

    [RelayCommand]
    async Task SelectTable(Table selectedTable)
    {
        if (selectedTable is null)
            return;

        await Shell.Current.GoToAsync(nameof(Views.ClientNumberPage), true, new Dictionary<string, object>
        {
            { "SelectedTable", selectedTable }
        });
    }
}

