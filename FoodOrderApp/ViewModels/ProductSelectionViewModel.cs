using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FoodOrderApp.Data;
using FoodOrderApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace FoodOrderApp.ViewModels;

public partial class ProductSelectionViewModel : ObservableObject
{
    private readonly OrderAppDbContext _dbContext;

    [ObservableProperty]
    private ObservableCollection<Product> products = new(); 

    [ObservableProperty]
    private ObservableCollection<OrderItem> orderItems = new();

    [ObservableProperty]
    private Table selectedTable;

    [ObservableProperty]
    private int clientCount;

    [ObservableProperty]
    private decimal totalAmount;

    public ProductSelectionViewModel(OrderAppDbContext dbContext)
    {
        _dbContext = dbContext;
        LoadProducts();
    }

    private void LoadProducts()
    {
        if (!_dbContext.Products.Any())
        {
            _dbContext.Products.AddRange(
                new Product { Name = "Burger", Price = 9.99m },
                new Product { Name = "Pizza", Price = 12.50m },
                new Product { Name = "Salad", Price = 6.00m },
                new Product { Name = "Drink", Price = 2.50m }
            );
            _dbContext.SaveChanges();
        }

        Products = new ObservableCollection<Product>(_dbContext.Products);
    }

    [RelayCommand]
    void AddToOrder(Product product)
    {
        var existing = OrderItems.FirstOrDefault(o => o.Product.Id == product.Id);
        if (existing != null)
        {
            existing.Quantity++;
        }
        else
        {
            OrderItems.Add(new OrderItem
            {
                Product = product,
                Quantity = 1
            });
        }

        RecalculateTotal();
    }

    private void RecalculateTotal()
    {
        TotalAmount = OrderItems.Sum(i => i.Product.Price * i.Quantity);
    }

    // Clears the order
    public void ClearOrder()
    {
        OrderItems.Clear();
        OnPropertyChanged(nameof(OrderItems));
        OnPropertyChanged(nameof(Total));
        //set total 0 as value
        TotalAmount = 0;
    }
    public decimal Total => OrderItems.Sum(item => item.Quantity * item.Product.Price);
 

    [RelayCommand]
    async Task SubmitOrder()
    {
        var order = new Order
        {
            Table = SelectedTable,
            TableId = SelectedTable.Id,
            ClientCount = ClientCount,
            Date = DateTime.Now,
            Items = OrderItems.ToList()
        };

        foreach (var item in order.Items)
        {
            item.ProductId = item.Product.Id;
        }

        _dbContext.Orders.Add(order);
        await _dbContext.SaveChangesAsync();

        await Shell.Current.DisplayAlert("Success", "Order submitted!", "OK");
        await Shell.Current.GoToAsync($"///{nameof(MainPage)}");
    }
}
