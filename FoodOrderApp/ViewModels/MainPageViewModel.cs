using FoodOrderApp.Data;
using FoodOrderApp.Models;
using FoodOrderApp.Views;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace FoodOrderApp.ViewModels
{


    public class MainPageViewModel : BaseViewModel
    {
        private readonly OrderAppDbContext _dbContext;
        public ICommand GoToTableSelectionCommand { get; }
        public ICommand GoToClientNumberCommand { get; }
        public ICommand GoToProductSelectionCommand { get; }

        public MainPageViewModel()
        {
            // Default constructor for XAML binding
        }
        public MainPageViewModel(OrderAppDbContext dbContext)
        {
            _dbContext = dbContext;

            GoToTableSelectionCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync(nameof(TableSelectionPage));
            });

            GoToClientNumberCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync(nameof(ClientNumberPage));
            });

            GoToProductSelectionCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync(nameof(ProductSelectionPage));
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

}


