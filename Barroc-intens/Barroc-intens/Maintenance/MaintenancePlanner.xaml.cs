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
using Microsoft.EntityFrameworkCore;
using Barroc_intens.Data;
using System.ComponentModel.Design;
using System.Collections.ObjectModel;
using System.Configuration;
using Windows.UI;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Barroc_intens
{
    public class UsedMaintenanceProduct
    {
        public MaintenanceProduct Product { get; set; }
        public int Quantity { get; set; }
    }


    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MaintenancePlanner : Window
    {
        private List<Company> companies;

        private List<Product> products;

        private List<MaintenanceProduct> maintenanceProducts;

        private ObservableCollection<MaintenanceProduct> productList;
        public ObservableCollection<MaintenanceProduct> Products { get; set; }
        public MaintenancePlanner()
        {
            this.InitializeComponent();
            using var db = new AppDbContext();
            
            // listbox met companies die beschikbaar zijn laten zien //
            using (var dbContext = new AppDbContext())
            {
                companies = dbContext.Companies.ToList();
                CompanyListBox.ItemsSource = companies;

                maintenanceProducts = dbContext.MaintenanceProducts.ToList();
                cmbProducts.ItemsSource= maintenanceProducts;

                products = dbContext.Products.ToList();
                ProductListBox.ItemsSource = products;
            }
        }

        private void Bcreate_Click(object sender, RoutedEventArgs e)
        {
            using var db = new AppDbContext();

            foreach (var i in lstProducts.Items)
            {
                var item = (UsedMaintenanceProduct)i;

                var selectedProduct = db.MaintenanceProducts.Find(item.Product.Id);

                

                if (selectedProduct != null)
                {
                    selectedProduct.Storage -= item.Quantity;
                }
            }

            lstProducts.Items.Clear();


            if (string.IsNullOrEmpty(tbRemark.Text))
            {
                MessageBox.Text = "Ongeldige gegevens"; 
                return;
            }
            else
            {
                var selectedCompany = (Company)CompanyListBox.SelectedItem;
                var companyId = selectedCompany.Id;

                var selectedProduct = (Product)ProductListBox.SelectedItem;
                var productId = selectedProduct.Id;

                // Opslaan van ingevulde gegevens //
                
                db.MaintenanceAppointments.Add(new MaintenanceAppointment
                {
                    ProductId = productId,
                    CompanyId = companyId,
                    
                    Description = tbRemark.Text,
                    Location = tbLocation.Text,
                    EmployeeId = 2,
                    ScheduledAt = tbDateAdded.Date.Date
                });



                
            }
            db.SaveChanges();
            this.Close();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Add selected product and quantity to the list view
            if (cmbProducts.SelectedItem != null && !string.IsNullOrEmpty(txtQuantity.Text))
            {
                int productId = (int)cmbProducts.SelectedValue;
  
                int quantityUsed;



                if (int.TryParse(txtQuantity.Text, out quantityUsed))
                {
                    
                    var selectedProduct = (MaintenanceProduct)cmbProducts.SelectedItem;
                    var productName = selectedProduct.Name;


                    if (selectedProduct != null && quantityUsed <= selectedProduct.Storage)
                    {
                        //selectedProduct.Storage -= quantityUsed;
                        lstProducts.Items.Add(new UsedMaintenanceProduct { Product = selectedProduct, Quantity = quantityUsed });
                    }
                    else
                    {
                        MessageBox.Text ="Not enough stock available.";
                    }
                }
                else
                {
                    MessageBox.Text= "Please enter a valid quantity.";
                }
            }
            else
            {
                MessageBox.Text= "Please select a product and enter the quantity.";
            }
        }

        private void bBack_Click(object sender, RoutedEventArgs e)
        {
            var maintenanceWindow = new MaintenanceWerkbonnen();
            maintenanceWindow.Activate();
            this.Close();
        }
    }
}