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
using Barroc_intens.Data;
using Microsoft.EntityFrameworkCore;
using Barroc_intens.Model;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Barroc_intens
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class StoringDetailsWindow : Window
    {
        public StoringDetailsWindow(FaultyRequest selectedStoring)
        {
            this.InitializeComponent();

            using (var db = new AppDbContext())
            {
                

                var storingDetail = db.FaultyRequests
                    .Include(sd => sd.Product)
                    .Include(sd => sd.Employee)
                    .ToList()
                    .Where(sd => sd.Id == selectedStoring.Id);
                    
                storingDetailsListView.ItemsSource = storingDetail;
            }
        }

        private void BGoBack_Click(object sender, RoutedEventArgs e)
        {
            var windowPlanner = new MaintenancePlanner();
            windowPlanner.Activate();
            windowPlanner.Closed += Window_Closed;
        }

        private void Window_Closed(object sender, WindowEventArgs args)
        {
        
            using (var db = new AppDbContext())
            {
                var maintenance = db.MaintenanceAppointments.ToList();
                NoteListview.ItemsSource = db.MaintenanceAppointments.Include(c => c.Company);

            }

        }
    }
}
