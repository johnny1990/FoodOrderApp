
using FoodOrderApp.Data;
using FoodOrderApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace FoodOrderApp.ViewModels
    {
        public class AllOrdersViewModel
        {
            public ObservableCollection<Order> Orders { get; set; } = new();

            public AllOrdersViewModel()
            {
                LoadOrders();
            }

            private void LoadOrders()
            {
                using var db = new OrderAppDbContext();
                var allOrders = db.Orders.Include(o => o.Items).OrderByDescending(o => o.CreatedAt).ToList();
                Orders = new ObservableCollection<Order>(allOrders);
            }
        }
    }


