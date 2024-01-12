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
    public sealed partial class KlantenWindow : Window
    {
        public KlantenWindow()
        {
            this.InitializeComponent();
            using var db = new AppDbContext();
            var products = db.Products.ToList();
            lvProducts.ItemsSource = products;
        }

        private void BFactuur_Click(object sender, RoutedEventArgs e)
        {
            // TODO : Is deze methode nodig???
        }

        private void BStoring_Click(object sender, RoutedEventArgs e)
        {
            var storingWindow = new StoringsWindow();
            storingWindow.Activate();
            this.Close();
        }

        private void tbSearchbar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchInput = tbSearchbar.Text;

            using var db = new AppDbContext();
            lvProducts.ItemsSource = db.Products.Where(p => p.Name.Contains(searchInput));
        }

        private void BContactinformatie_Click(object sender, RoutedEventArgs e)
        {
            // TODO : voor contact functie die niet hoefde in de sprint
        }

        private void BContact_Click(object sender, RoutedEventArgs e)
        {
            // TODO : voor contact functie die niet hoefde in de sprint
        }
    }
}
