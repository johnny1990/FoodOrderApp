
using FoodOrderApp.Data;
using FoodOrderApp.Models;
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
                var allOrders = db.Orders.OrderByDescending(o => o.CreatedAt).ToList();
                Orders = new ObservableCollection<Order>(allOrders);
            }
        }
    }


