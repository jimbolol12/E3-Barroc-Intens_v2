using Barroc_intens.Data;
using Barroc_intens.Maintenance;
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
    public sealed partial class MaintenanceWerkbonnen : Window
    {
        public MaintenanceWerkbonnen()
        {
            this.InitializeComponent();

            LoadAppointments();
        }
        private void Window_Closed(object sender, WindowEventArgs args)
        {
            LoadAppointments();
        }

        private void BRedirectToPlannerWindow_Click(object sender, RoutedEventArgs e)
        {
            var windowPlanner = new MaintenancePlanner();
            windowPlanner.Activate();
            windowPlanner.Closed += Window_Closed;

        }
        private void SPWerkbon_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            // Ga naar edit pagina van de appointment waar 2 keer op is gedrukt
            if (e.OriginalSource is FrameworkElement element && element.DataContext is MaintenanceAppointment selectedAppointment)
            {
                var SelectedWerkbonWindow = new MaintenanceEditWerkbonWindow(selectedAppointment);
                SelectedWerkbonWindow.Activate();
                this.Close();
            }
        }

        private void BDeleteSelectedAppointment_Click(object sender, RoutedEventArgs e)
        {
            if (NoteListview.SelectedItem is MaintenanceAppointment selectedAppointment && NoteListview.SelectedItem != null)
            {
                using (var db = new AppDbContext())
                {
                    db.MaintenanceAppointments.Remove(selectedAppointment);
                    db.SaveChanges();

                    var maintenance = db.MaintenanceAppointments.ToList();
                    NoteListview.ItemsSource = db.MaintenanceAppointments.Include(c => c.Company);
                }
            }
         /*   else
            {
                MessageBox.Text = "Selecteer een afspraak";
            }*/
        }
        public void LoadAppointments()
        {
            /* using (var db = new AppDbContext())
             {
                 var maintenance = db.MaintenanceAppointments.ToList();
                 AppointmentListview.ItemsSource = db.MaintenanceAppointments
                                                     .Include(c => c.Company)
                                                     .Include(p => p.Product)
                                                     .ToList();
             }*/
            using (var db = new AppDbContext())
            {
                // Database aan maken en verwijderen //
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                // Model product en company in laden//
                NoteListview.ItemsSource = db.MaintenanceAppointments
                    .Include(g => g.Product)
                    .Include(c => c.Company);
            }
        }

    }
}
