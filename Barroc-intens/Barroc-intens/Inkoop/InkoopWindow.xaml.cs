using Barroc_intens.Data;
using Barroc_intens.Inkoop;
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
                var maintenanceProducts = db.MaintenanceProducts.ToList();

                // Filter de maintenanceProducts die een storrage van minder dan 50 hebben
                var lowStorrageProducts = maintenanceProducts.Where(mp => mp.Storage < 50).ToList();

                // Controleer of er producten zijn met een storrage van minder dan 50
                if (lowStorrageProducts.Count > 0)
                {
                    // Voeg de onder50StorrageProducts toe aan je lijst of doe er iets anders mee
                    // Bijvoorbeeld, je kunt ze doorlopen en iets doen met elk product
                    foreach (var product in lowStorrageProducts)
                    {
                        productListBox.Items.Add(product.Name);

                    }

                    // Laat een bericht zien of neem andere acties
                    storagemelding.Text = "deze producten moeten bij besteld worden";
                }
            }
            }


        private void BStorage_Click(object sender, RoutedEventArgs e)
        {
            var storageWindow = new StorageWindow();
            storageWindow.Activate();
            this.Close();
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
