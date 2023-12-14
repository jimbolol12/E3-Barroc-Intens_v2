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
    public sealed partial class FinanceWindow : Window
    {
        public FinanceWindow()
        {
            this.InitializeComponent();
            LoadCompanyDb();


        }
        private void LoadCompanyDb () {
            using (var db = new AppDbContext())
            {
                var company = db.Companies
                    .Include(c => c.Contact)
                    .ToList();
                     
                
                companieListView.ItemsSource = company;
            }
        }
        private void Bleasecontract_Click(object sender, RoutedEventArgs e)
        {
            var leasewindow = new LeasecontractWindow();
            leasewindow.Activate();
            this.Close();
        }

        private void TBBkrCheck_Click(object sender, RoutedEventArgs e)
        {
            var toggle = (ToggleButton)sender;
            if (toggle.IsChecked == true)
            {
                var companyId = (int)toggle.Tag;

                using (var db = new AppDbContext())
                {
                    var company = db.Companies.Single(c => c.Id == companyId);
                    var now = DateTime.Now;
                    company.BkrCheckedAt = DateOnly.FromDateTime(now);
                    db.SaveChanges();
                }
            }
            else if (toggle.IsChecked == false)
            {
                var companyId = (int)toggle.Tag;

                using (var db = new AppDbContext())
                {
                    var company = db.Companies.Single(c => c.Id == companyId);
                    company.BkrCheckedAt = null;
                    db.SaveChanges();
                }
            }
            LoadCompanyDb();
        }

    }
}
