using Barroc_intens.Data;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Barroc_intens
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class InkoopWindow : Window
    {
        public InkoopWindow()
        {
            this.InitializeComponent();

            using (var db = new AppDbContext())
            {
                var products = db.MaintenanceProducts
                    .ToList();
                lvMaintenanceProducts.ItemsSource = products;
            }
        }

        private void BStorage_Click(object sender, RoutedEventArgs e)
        {
            //TODO
        }

        private void BProduct_Click(object sender, RoutedEventArgs e)
        {
            var productWindow = new ProductenWindow();
            productWindow.Activate();
            this.Close();
        }

        private void bBack_Click(object sender, RoutedEventArgs e)
        {
            var loginWindow = new LoginWindow();
            loginWindow.Activate();
            this.Close();
        }
    }
}
