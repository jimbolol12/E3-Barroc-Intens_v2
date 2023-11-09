using Barroc_intens.Model;
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
    public sealed partial class ProductenWindow : Window
    {
        public ProductenWindow()
        {
            this.InitializeComponent();
            using var db = new AppDbContext();
            var products = db.Products.ToList();
            lvProducts.ItemsSource = products;
        }

        private void lvProducts_ItemClick(object sender, ItemClickEventArgs e)
        {
            var selectedProduct = (Product)e.ClickedItem;
            tbSelectedProductname.Text = selectedProduct.Name;
            tbSelectedProductdimensions.Text = selectedProduct.Dimensions;
            tbSelectedProductdescription.Text = selectedProduct.Description;
            tbSelectedProductprice.Text = selectedProduct.PriceFormatted;
            tbSelectedProductstorage.Text = selectedProduct.StorageFormatted;
        }

        private void BCreateProduct_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BEditProduct_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BDeleteProduct_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
