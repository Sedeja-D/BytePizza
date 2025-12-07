//WPF code logic for the MainWindow. Bridges gap between the desktop
//host and the Blazor UI.
using Microsoft.Extensions.DependencyInjection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BytePizza
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Resources.Add("services", App.ServiceProvider);
        }
    }
}