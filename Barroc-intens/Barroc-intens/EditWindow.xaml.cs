using Barroc_intens.Data;
using Barroc_intens.Model;
using Microsoft.EntityFrameworkCore;
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
    public sealed partial class EditWindow : Window
    {
        private Product clickedproduct;
        public EditWindow(Product selectedProduct)
        {
            this.InitializeComponent();

            this.clickedproduct = selectedProduct;

            using (var dbContext = new AppDbContext())               
            dbContext.Products.Attach(selectedProduct);
            tbProductname.Text = selectedProduct.Name;
            tbProductdimensions.Text = selectedProduct.Dimensions;
            tbProductdescription.Text = selectedProduct.Description;
            tbProductprice.Text = selectedProduct.PriceFormatted;

        }

        private void BSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                var product = clickedproduct;

                using var dbContext = new AppDbContext();

                var clickproduct = dbContext.Products.Find(clickedproduct.Id);

                clickproduct.Name = tbProductname.Text;
                clickproduct.Dimensions = tbProductdimensions.Text;
                clickproduct.Description = tbProductdescription.Text;
                clickproduct.Price = decimal.Parse(tbProductprice.Text);

                dbContext.SaveChanges();

                this.Close();

            }
            catch (FormatException)
            {
                // Hier kun je de foutmelding weergeven voor ongeldige gegevens
                /* MessageBox.Show("Ongeldige gegevens. Controleer of de ingevoerde waarden correct zijn.");*/
                MessageBox.Text = "Incorecte gegevens ingevuld";
            }
            catch (Exception ex)
            {
                // Hier kun je een algemene foutmelding weergeven voor andere uitzonderingen
                /* MessageBox.Show($"Er is een fout opgetreden: {ex.Message}");*/
                MessageBox.Text = "Incorecte gegevens ingevuld";
            }
        }
    }
}
