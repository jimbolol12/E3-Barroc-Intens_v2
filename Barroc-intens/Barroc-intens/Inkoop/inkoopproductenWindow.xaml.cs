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
using static System.Net.WebRequestMethods;
using System.Configuration;
using Barroc_intens.Data;
using Barroc_intens.Model;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Barroc_intens.Inkoop
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class inkoopproductenWindow : Window
    {
        public inkoopproductenWindow()
        {
            this.InitializeComponent();

            using (var db = new AppDbContext())
            {
                var maintenanceProducts = db.MaintenanceProducts
                    .ToList();
                lvMaintenanceProducts.ItemsSource = maintenanceProducts;
            }
        }

        private async void AddQuantity_Click(object sender, RoutedEventArgs e)
        {
            ErrorTextBlock.Text = ""; 
            if (lvMaintenanceProducts.SelectedItem is MaintenanceProduct selectedProduct)
            {
                if (int.TryParse(ProductQuantity.Text, out int quantity) && quantity > 0)
                {
                    using var db = new AppDbContext();
                    selectedProduct.Storage += quantity;
                    db.Update(selectedProduct);
                    db.SaveChanges();

                    lvMaintenanceProducts.ItemsSource = db.MaintenanceProducts.OrderByDescending(p => p.Id);
                }
                else
                {
                    ErrorTextBlock.Text = "Invalid quantity. Please enter a valid positive integer.";
                }
            }
            else
            {
                ErrorTextBlock.Text = "No product selected. Please choose a product to update.";
            }
        }
        private void bBack_Click(object sender, RoutedEventArgs e)
        {
            var StorageWindow = new StorageWindow();
            StorageWindow.Activate();
            this.Close();
        }
    }
}


    
