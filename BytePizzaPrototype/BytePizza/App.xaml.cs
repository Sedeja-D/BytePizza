//WPF app level bootstrapper & host. Controls application startup
//and shutdown for desktop app. Controls app-wide initializations
//of WPF resources. We will most likely have no reason to work
//within this file during development as we are utilizing Blazor UI.

using BytePizza.Data;
using BytePizza.Services;
using BytePizza.Services.Implementations;
using BytePizza.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;
using System.IO;
using System.Windows;

namespace BytePizza
{
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; } = null!;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var services = new ServiceCollection();
            var databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BytePizza.db");
            services.AddDbContext<ApplicationDBContext>(options => options.UseSqlite($"Data Source= {databasePath}"));

            //Business logic registration
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IOrderService, OrderService>();
            //New for the placing of order into Database
            services.AddSingleton<CartService>();


        
            services.AddWpfBlazorWebView();


            //Assists with debugging Blazor specific features while the app is in development
            #if DEBUG
            services.AddBlazorWebViewDeveloperTools();
            #endif


            ServiceProvider = services.BuildServiceProvider();
            //Database Initialization
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDBContext>();
                SeedData.Initialize(context);
            }
        }
    }
}
