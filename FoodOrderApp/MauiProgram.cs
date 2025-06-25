using FoodOrderApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace FoodOrderApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "foodorder.db");

        builder.Services.AddDbContext<OrderAppDbContext>();

        // Add ViewModels as services
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<ViewModels.MainPageViewModel>();
        builder.Services.AddSingleton<ViewModels.TableSelectionViewModel>();
        builder.Services.AddSingleton<ViewModels.ClientNumberViewModel>();
        builder.Services.AddSingleton<ViewModels.ProductSelectionViewModel>();

        // Add Pages as services
        builder.Services.AddSingleton<MainPage>();

        builder.Services.AddSingleton<Views.TableSelectionPage>();
        builder.Services.AddSingleton<Views.ClientNumberPage>();
        builder.Services.AddSingleton<Views.ProductSelectionPage>();

        return builder.Build();
    }
}

