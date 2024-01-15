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
    public sealed partial class HoofdmedewerkerMaintenanceWindow : Window
    {
        public HoofdmedewerkerMaintenanceWindow()
        {
            this.InitializeComponent();

            using (var db = new AppDbContext())
            {
                var request = db.FaultyRequests
                     .ToList();
                lvFaultyRequests.ItemsSource = request;

                var products = db.MaintenanceProducts
                    .ToList();
                lvMaintenanceProducts.ItemsSource = products;
            }
        }

        private void BRedirectWerkbonnenWindow_Click(object sender, RoutedEventArgs e)
        {
            var werkbonnenWindow = new MaintenanceWerkbonnen();
            werkbonnenWindow.Activate();
            this.Close();
        }
        private void bBack_Click_1(object sender, RoutedEventArgs e)
        {
            var maintenanceWindow = new MaintenanceWerkbonnen();
            maintenanceWindow.Activate();
            this.Close();
        }
    }
}
