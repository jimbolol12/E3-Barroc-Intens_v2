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
            /*var selectedProduct = (Product)e.ClickedItem;*/

          /*  var editWindow = new EditWindow(selectedProduct);
            editWindow.Activate();
            this.Close();*/
        }

        private void BCreateProduct_Click(object sender, RoutedEventArgs e)
        {
          /*  var createWindow = new CreateWindow();
            createWindow.Activate();
            this.Close();*/
        }

        private void BDeleteProduct_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
