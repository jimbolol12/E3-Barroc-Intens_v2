using Barroc_intens.Data;
<<<<<<< HEAD
using Barroc_intens.Model;
using Microsoft.UI;
=======
using Microsoft.EntityFrameworkCore;
>>>>>>> MaintanenceWerkbronnenWindow
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.Drawing;
=======
>>>>>>> MaintanenceWerkbronnenWindow
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
<<<<<<< HEAD
    public sealed partial class MaintenanceWindow : Window
    {
        public MaintenanceWindow()
        {
            this.InitializeComponent();


        }

        private void BStoringRedirect_Click(object sender, RoutedEventArgs e)
        {
<<<<<<<< HEAD:Barroc-intens/Barroc-intens/Maintenance/MaintenanceWindow.xaml.cs
            var maintenanceStoringenWindow = new MaintenanceStoringenWindow();
            maintenanceStoringenWindow.Activate();
            this.Close();



        }
        private void CalendarView_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {

        }
        private void CalendarView_CalendarViewDayItemChanging(CalendarView sender, CalendarViewDayItemChangingEventArgs args)
        {

========
            try
            {
                using var db = new AppDbContext();
                db.Products.Add(new Product
                {
                    Id = tbProductid.Text,
                    Name = tbProductname.Text,
                    Dimensions = tbProductdimensions.Text,
                    Description = tbProductdescription.Text,
                    Price = decimal.Parse(tbProductprice.Text),
                    Storage = int.Parse(tbProductstorage.Text),
                });
                db.SaveChanges();

                var productWindow = new ProductenWindow();
                productWindow.Activate();
                this.Close();
            }
            catch (FormatException)
            {
                // Hier kun je de foutmelding weergeven voor ongeldige gegevens
                MessageBox.Text = "Ongeldige gegevens";
            }
            catch (Exception ex)
            {
                // Hier kun je een algemene foutmelding weergeven voor andere uitzonderingen
                MessageBox.Text = "Ongeldige gegevens";
            }
>>>>>>>> MaintanenceWerkbronnenWindow:Barroc-intens/Barroc-intens/CreateWindow.xaml.cs
        }
    }
}

=======
    public sealed partial class LeasecontractWindow : Window
    {
        public ImageSource Source { get; set; }
        public LeasecontractWindow()
        {
            this.InitializeComponent();
        }

        private void BNieuwLeaseContract_Click(object sender, RoutedEventArgs e)
        {
            var newLeaseWindow = new CreateNewLeaseWindow();
            newLeaseWindow.Activate();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new MaintenanceWerkbonnen();
            window.Activate();
        }
    }
}
>>>>>>> MaintanenceWerkbronnenWindow
