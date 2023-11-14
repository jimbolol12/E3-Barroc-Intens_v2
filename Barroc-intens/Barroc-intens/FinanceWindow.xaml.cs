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
    public sealed partial class FinanceWindow : Window
    {
        public FinanceWindow()
        {
            this.InitializeComponent();

            using (var db = new AppDbContext())
            {
                var company = db.Companies
                 /* .Include(m => m.Id)*/
                 .ToList();

                companieListView.ItemsSource = company;
            }
        }

        private void Bleasecontract_Click(object sender, RoutedEventArgs e)
        {
            var leaseWindow = new LeasecontractWindow();
            leaseWindow.Activate();
            this.Close();
        }

        private void BLeaseContract_Click(object sender, RoutedEventArgs e)
        {
            var leaseContractWindow = new LeaseContractWindow();
            leaseContractWindow.Activate();
            this.Close();
        }
    }
}
