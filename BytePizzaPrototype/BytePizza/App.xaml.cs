//WPF app level bootstrapper & host. Controls application startup
//and shutdown for desktop app. Controls app-wide initializations
//of WPF resources. We will most likely have no reason to work
//within this file during development as we are utilizing Blazor UI.

using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using BytePizza.Data;
using BytePizza.Services.Interfaces;
using BytePizza.Services.Implementations;
using System.Configuration;
using System.IO;
using System.Windows;
using System;

namespace BytePizza
{
    public partial class App : Application
    {
        ///<summary>
        ///Provides Dependency Injection Globally. This is how Blazor Components will get sevice instances.
        ///</summary>
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

            ///<summary>
            ///Configuring blazor
            ///</summary>
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
