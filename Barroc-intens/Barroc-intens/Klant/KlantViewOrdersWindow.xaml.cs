using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Barroc_intens.Model;
using Barroc_intens.Data;
using Microsoft.EntityFrameworkCore;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Barroc_intens.Klant
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class KlantViewOrdersWindow : Window
    {
        public static User LoggedInUser { get; private set; }

        public KlantViewOrdersWindow(User currentUser)
        {
            this.InitializeComponent();
            LoggedInUser = currentUser;

            using (var db = new AppDbContext())
            {
                //var customInvoiceProducts = 
                ordersListView.ItemsSource = db.CustomInvoiceProducts
                .Where(cip => cip.CustomInvoice.Company.Id == LoggedInUser.CompanyId)
                .Include(p => p.Product)
                .ToList(); 
            }
        }

        private void BRedirectBack_Click(object sender, RoutedEventArgs e)
        {
            var klantWindow = new KlantenWindow(LoggedInUser);
            klantWindow.Activate();
            this.Close();
        }

        private async void ordersListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var clickedOrder = e.ClickedItem as CustomInvoiceProduct;
            DateTime productPayDate;
            DateTime dateOrdered;
            using (var db = new AppDbContext())
            {
                var customInvoice = db.CustomInvoices.Single(ci => ci.Id == clickedOrder.CustomInvoiceId);
                productPayDate = (DateTime)customInvoice.PaidAt;
                dateOrdered = customInvoice.Date;
            }

            var productName = clickedOrder.Product.Name.ToString();
            var productDesc = clickedOrder.Product.Description.ToString(); 
            var productPrice = clickedOrder.Product.PriceFormatted.ToString();
            string productPaid = "";
            
            
            if (productPayDate == default(DateTime))
            {
                productPaid = "Product is nog niet betaalt!";
            }
            else
            {
                productPaid = "Product is betaalt!";
            }
            

            if (clickedOrder != null && clickedOrder.Product != null)
            {
                ContentDialog CdShowOrderDetails = new ContentDialog
                {
                    Title = $" Product: {productName}",
                    Content = $" Datum Besteld: {dateOrdered}\n Product Prijs: {productPrice}\n {productPaid}",
                    CloseButtonText = "Ok",
                    XamlRoot = this.Content.XamlRoot,
                };

                ContentDialogResult result = await CdShowOrderDetails.ShowAsync();
                return;
            }
        }
    }
}
