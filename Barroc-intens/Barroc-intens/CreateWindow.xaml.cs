using Barroc_intens.Data;
using Barroc_intens.Model;
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
    public sealed partial class CreateWindow : Window
    {
        public CreateWindow()
        {
            this.InitializeComponent();
        }

        private void Bcreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using var db = new AppDbContext();
                db.Products.Add(new Product
                {
                    Id = tbProductid.Text,
                    Name = tbProductname.Text,
                    Dimensions = tbProductdimensions.Text,
                    Description = tbProductdescription.Text,
                    Price = decimal.Parse(tbProductprice.Text),
                    Storage = int.Parse(tbProductstorage.Text),
                });
                db.SaveChanges();

                var productWindow = new ProductenWindow();
                productWindow.Activate();
                this.Close();
            }
            catch (FormatException)
            {
                // Hier kun je de foutmelding weergeven voor ongeldige gegevens
                MessageBox.Show("Ongeldige gegevens. Controleer of de ingevoerde waarden correct zijn.");
            }
            catch (Exception ex)
            {
                // Hier kun je een algemene foutmelding weergeven voor andere uitzonderingen
                MessageBox.Show($"Er is een fout opgetreden: {ex.Message}");
            }
        }
    }
}
