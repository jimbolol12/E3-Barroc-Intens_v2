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
                UpdateProductAndSaveChanges();
                CloseCurrentWindow();
            }
            catch (FormatException)
            {
                HandleInvalidData("Incorrecte gegevens ingevuld");
            }
            catch (Exception ex)
            {
                HandleGeneralException($"Er is een fout opgetreden: {ex.Message}");
            }
        }

        private void UpdateProductAndSaveChanges()
        {
            var product = clickedproduct;

            using (var dbContext = new AppDbContext())
            {
                var existingProduct = dbContext.Products.Find(clickedproduct.Id);

                if (existingProduct != null)
                {
                    UpdateProductDetails(existingProduct);
                    dbContext.SaveChanges();
                }
            }
        }

        private void UpdateProductDetails(Product existingProduct)
        {
            existingProduct.Name = tbProductname.Text;
            existingProduct.Dimensions = tbProductdimensions.Text;
            existingProduct.Description = tbProductdescription.Text;
            existingProduct.Price = decimal.Parse(tbProductprice.Text);
        }

        private void CloseCurrentWindow()
        {
            this.Close();
        }

        private void HandleInvalidData(string errorMessage)
        {
            MessageBox.Text = errorMessage;
        }

        private void HandleGeneralException(string errorMessage)
        {
            MessageBox.Text = errorMessage;
        }
    }
}
