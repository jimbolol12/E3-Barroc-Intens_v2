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

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Barroc_intens
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MaintenancePlanner : Window
    {
        private List<Company> companies;

        private List<Product> products;
        public MaintenancePlanner()
        {
            this.InitializeComponent();
            using var db = new AppDbContext();

            // listbox met companies die beschikbaar zijn laten zien //
            using (var dbContext = new AppDbContext())
            {
                companies = dbContext.Companies.ToList();
                CompanyListBox.ItemsSource = companies;

                products = dbContext.Products.ToList();
                ProductListBox.ItemsSource = products;
            }
        }

        private void Bcreate_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbRemark.Text))
            {
                MessageBox.Text = "Ongeldige gegevens";
            }
            else
            {
                var selectedCompany = (Company)CompanyListBox.SelectedItem;
                var companyId = selectedCompany.Id;

                var selectedProduct = (Product)ProductListBox.SelectedItem;
                var productId = selectedProduct.Id;

                // Opslaan van ingevulde gegevens //
                using var db = new AppDbContext();
                db.MaintenanceAppointments.Add(new MaintenanceAppointment
                {
                    ProductId = productId,
                    CompanyId = companyId,
                    Description = tbRemark.Text,
                    Location = tbLocation.Text,
                    EmployeeId = 2,
                    ScheduledAt = tbDateAdded.Date.Date
                });

                db.SaveChanges();
                this.Close();
            }
        }

    }
}
