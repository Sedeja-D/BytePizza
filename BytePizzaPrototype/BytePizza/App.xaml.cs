//WPF app level bootstrapper & host. Controls application startup
//and shutdown for desktop app. Controls app-wide initializations
//of WPF resources. We will most likely have no reason to work
//within this file during development as we are utilizing Blazor UI.

using System.Configuration;
using System.Data;
using System.Windows;

namespace BytePizza
{
    public partial class App : Application
    {
    }

}
