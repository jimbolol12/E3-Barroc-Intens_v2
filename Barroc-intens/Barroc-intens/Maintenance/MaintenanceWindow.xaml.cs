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
    public sealed partial class MaintenanceWindow : Window
    {
        public MaintenanceWindow()
        {
            this.InitializeComponent();

            using (var db = new AppDbContext())
            {
                // Database aan maken en verwijderen //
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                // Model product en company in laden//
                var Faulty = db.FaultyRequests
                     .Include(g => g.Product).Include(g => g.User)
                     .ToList();

                FaultyRequestListView.ItemsSource = Faulty;
            }
        }

        // Niewe window openen //
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new MaintenanceWerkbonnen();
            window.Activate();
        }
    }
}
