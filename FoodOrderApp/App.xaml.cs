//using Android.Content;
using FoodOrderApp.Data;
using FoodOrderApp.Views;
using Microsoft.EntityFrameworkCore;
using System;

namespace FoodOrderApp
{
    public partial class App : Application
    {
        public App(OrderAppDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();

            MainPage = new AppShell();
        }
    }
}