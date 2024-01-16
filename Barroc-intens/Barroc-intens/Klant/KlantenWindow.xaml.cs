using Barroc_intens.Data;
using Barroc_intens.Klant;
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
    public sealed partial class KlantenWindow : Window
    {
        public static User LoggedInUser { get; private set; }

        public KlantenWindow(User currentUser)
        {
            this.InitializeComponent();
            using var db = new AppDbContext();
            var products = db.Products.Where(p => p.Category.IsEmployeeOnly == false).ToList();
            lvProducts.ItemsSource = products;
            LoggedInUser = currentUser;
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
            lvProducts.ItemsSource = db.Products.Where(p => p.Name.Contains(searchInput) && p.Category.IsEmployeeOnly == false);
        }

        private void BViewOrders_Click(object sender, RoutedEventArgs e)
        {
            var klantViewOrdersWindow = new KlantViewOrdersWindow(LoggedInUser);
            klantViewOrdersWindow.Activate();
            this.Close();
        }

        private async void lvProducts_ItemClick(object sender, ItemClickEventArgs e)
        {
            var clickedProduct = e.ClickedItem as Product;
            ContentDialog CdShowOrderConfirmation = new ContentDialog
            {
                Title = "Bestellen",
                Content = $"Weet u zeker dat de {clickedProduct.Name} wilt bestellen",
                IsPrimaryButtonEnabled = true,
                IsSecondaryButtonEnabled = true,
                PrimaryButtonText = "Ja",
                SecondaryButtonText = "Nee",
                XamlRoot = this.Content.XamlRoot,
            };
            CdShowOrderConfirmation.PrimaryButtonClick += (sender, e) =>
            {
                AddOrderedProduct(clickedProduct);
            };
            ContentDialogResult result = await CdShowOrderConfirmation.ShowAsync();
        }
        public void AddOrderedProduct(Product clickedProduct)
        {
            using var db = new AppDbContext();
            var customInvoices = db.CustomInvoices.ToList();

            db.CustomInvoices.Add(new CustomInvoice
            {
                Id = customInvoices.Count() + 1,
                Date = DateTime.Now,
                PaidAt = DateTime.Now,
                CompanyId = (int)LoggedInUser.CompanyId,
            });
            db.CustomInvoiceProducts.Add(new CustomInvoiceProduct
            {
                PricePerProduct = clickedProduct.Price,
                ProductId = clickedProduct.Id,
                CustomInvoiceId = customInvoices.Count() + 1,
            });
            db.SaveChanges();
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
