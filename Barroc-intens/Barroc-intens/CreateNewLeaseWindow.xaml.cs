using Barroc_intens.Data;
using Barroc_intens.Model;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Documents;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Preview.Notes;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Search;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Barroc_intens
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateNewLeaseWindow : Window
    {
        public CreateNewLeaseWindow()
        {
            this.InitializeComponent();

            using (var db = new AppDbContext())
            {
                var company = db.Companies
                 /* .Include(m => m.Id)*/
                 .ToList();

                CompanyCombobox.ItemsSource = company;
            }
        }

        private void BSaveContract_Click(object sender, RoutedEventArgs e)
        {
            var company = CompanyCombobox.SelectedItem as Company;

            using (var db = new AppDbContext())
            {
                var companyId = db.Companies.Single(c => c.Id == company.Id);
                var now = DateTime.Now;
                companyId.BkrCheckedAt = DateOnly.FromDateTime(now);
                db.SaveChanges();
            }
            
            var financeWindow = new FinanceWindow();
            financeWindow.Activate();

            this.Close();
        }

        
    }
}
