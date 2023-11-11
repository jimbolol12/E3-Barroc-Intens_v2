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
        public EditWindow(Product selectedProduct)
        {
            this.InitializeComponent();

            using (var dbContext = new AppDbContext())
            {
                dbContext.Products.Attach(selectedProduct);
                tbProductname.Text = selectedProduct.Name;
                tbProductdimensions.Text = selectedProduct.Dimensions;
                tbProductdescription.Text = selectedProduct.Description;
                tbProductprice.Text = selectedProduct.PriceFormatted;
                tbProductstorage.Text = selectedProduct.StorageFormatted;
            }

        }

        private void BSave_Click(object sender, RoutedEventArgs e)
        {
            using var dbContext = new AppDbContext();
            dbContext.SaveChanges();
            BSave.Content = "Saved!!";
        }
    }
}
