using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Barroc_intens.Data;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Barroc_intens.Inkoop
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StorageWindow : Window
    {
        public StorageWindow()
        {
            this.InitializeComponent();

            using (var db = new AppDbContext())
            {
                var maintenanceProducts = db.MaintenanceProducts
                    .ToList();
                lvMaintenanceProducts.ItemsSource = maintenanceProducts;

                if (maintenanceProducts.Count < 50) 
                {

                    melding.Text = "Producten zijn laag op storage";
                }

                var products = db.Products
                    .ToList();
                lvProducts.ItemsSource = products;
            }
        }

        private void bBack_Click(object sender, RoutedEventArgs e)
        {
            var inkoopWindow = new InkoopWindow();
            inkoopWindow.Activate();
            this.Close();
        }

        private void binkoopen_Click(object sender, RoutedEventArgs e)
        {
            var inkoopproductenWindow = new inkoopproductenWindow();
            inkoopproductenWindow.Activate();
            this.Close();
        }
    }
}
